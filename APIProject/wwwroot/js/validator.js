
// Đối tượng 'Validator'
function Validator(options) {
    
    
    function getParent(element, selector) {
        while(element.parentElement) {
            if(element.parentElement.matches(selector)) {
                return element.parentElement
            }
            element = element.parentElement;
        }
    }

    var selectorRules = {};

    // Hàm thực hiện validate
    var validate = function(inputElement, rule) {
        // value: inputElement.value (cái mà user nhập vào)
        // test function: rule.tests
         var errorElement = getParent(inputElement, options.formGroupSelector).querySelector(options.errorSelector) 
        // var errorElement = inputElement.parentElement.querySelector(options.errorSelector) 
        // dùng parentElement để select ngược ra thẻ cha, rồi lại select lấy thẻ con của nó. 
         var errorMessage // chỉ cần gọi lại vì nó lặp trong for rồi.

         // Lấy các rules của selector
         var rules = selectorRules[rule.selector]

             // Lặp qua từng rule và kiểm tra
            for(var i = 0; i < rules.length; i++) {
                switch(inputElement.type) {
                    case 'radio':
                    case 'checkbox':
                        errorMessage = rules[i](
                            formElement.querySelector(rule.selector + ':checked')
                        )
                        break;
                    default:
                        errorMessage = rules[i](inputElement.value)
                }
                if(errorMessage) break; // Nếu lỗi thì dừng kiểm tra.
            }
            
            if(errorMessage) {
                errorElement.innerHTML = errorMessage
                getParent(inputElement, options.formGroupSelector).classList.add('invalid')
            } else {
                errorElement.innerHTML = ''
                getParent(inputElement, options.formGroupSelector).classList.remove('invalid')
            }
            return !errorMessage // convert sang kiểu boolen
    }

    // lấy element của form cần validate
    var formElement = document.querySelector(options.form)
    if(formElement) {
        // Khi submit form
        formElement.onsubmit = function(e) {
            e.preventDefault();

            var isFormValid = true;
            // Thực hiện lặp qua từng rule và validate luôn.
             options.rules.forEach(function(rule) {
                var inputElement = formElement.querySelector(rule.selector)
                var isValid = validate(inputElement, rule) 
                if(!isValid) {
                    isFormValid = false;
                }
             });
               
             if(isFormValid) { // true
                 //Trường hợp submit với js
                 if(typeof options.onSubmit === 'function') {
                    var enableInputs = formElement.querySelectorAll('[name]:not([disabled])')
                    var formValues = Array.from(enableInputs).reduce(function(values, input){

                            switch(input.type){
                                    case 'radio':
                                        values[input.name] = formElement.querySelector('input[name="' + input.name + '"]:checked').value;
                                    case 'checkbox':
                                        if(!input.matches(':checked')) {
                                            if(typeof input === ''){
                                                values[input.name] = '';
                                            }
                                            return values;
                                        }

                                        if(!Array.isArray(values[input.name])) {
                                            values[input.name] = [];
                                        }

                                        values[input.name].push(input.value);

                                        break;
                                    default:
                                    values[input.name] = input.value;
                                    
                            }

                            return values;  
                    }, {}); //gán cho initialvalue 1 object

                     options.onSubmit(formValues)
                 } 
                 // Trường hợp submit với hàh vi mặc định
                 else {
                     formElement.submit();
                 }
                 
             } 
        }


        // Xử lý lặp qua mỗi rule và xử lý ( lắng nghe sự kiện blur, input, ...)
        options.rules.forEach(function(rule) {

            // Lưu lại các rules cho mỗi input, sử dụng dấu ngoặc vuông làm key của object.
            if(Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test);
                // nếu nó là cái mảng push cho nó cái rule tiếp theo.
            } else {
                selectorRules[rule.selector] = [rule.test];
                 // nếu nó không phải là array th gán cho nó 1 array là rule đầu tiên
            }
 
            var inputElements = formElement.querySelectorAll(rule.selector) // s
            Array.from(inputElements).forEach(function(inputElement) {
                 // Xử lý trường hợp blur ra ngoài
                inputElement.onblur = function() {
                    validate(inputElement, rule) // truyền lại đối số
                }

                // Xử lý mỗi khi người dùng nhập vào input
                inputElement.oninput = function () {
                    var errorElement = getParent(inputElement, options.formGroupSelector).querySelector(options.errorSelector) 
                    errorElement.innerHTML = ''
                    getParent(inputElement, options.formGroupSelector).classList.remove('invalid')
                }
            })
        });
    }
}

// Định nghĩa các rules:
// Nguyên tắc của các rules :
//1.Có lỗi => trả message lỗi.
//2.Hợp lệ => Không trả cái gì cả (undefined)

// String,Int:
Validator.isRequired = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            if(typeof value === 'string') { // kiểm tra các value khác string
                return value.trim() ? undefined : message || 'Please enter this field! You are missing here.'
            } 
            return value ? undefined : message || 'Please enter this field! You are missing here.' 
        }
    }
}

//Email:
Validator.isEmail = function (selector, message) {
      return {
        selector: selector,
        test: function (value) {
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : message || 'Your email is not in correct format!'
         }
    }
}

// Password:
Validator.minLength = function (selector, min, message) {
      return {
        selector: selector,
        test: function (value) {
            return value.length >= min ? undefined : message || `Please enter at least ${min} characters!`;
         }
    }
}

Validator.isConfirmed = function (selector, getConfirmValue, message) {
      return {
        selector: selector,
        test: function (value) {
            return value === getConfirmValue() ? undefined : message || 'Please enter this field again! Your input is not correct.'
         } // Message là 1 custom đưa vào để thông báo khi người dùng không nhập gì
    }
}