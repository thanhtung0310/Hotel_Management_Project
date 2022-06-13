// tạo ra các rules trùng tên với tên attribute 
function Validator (formSelector) { //, options = {} gán cho tham số options bằng 1 mảng rỗng làm giá trị mặc định (ES6)
    var _this = this;
    var formRules = {}; 

    function getParent(element, selector) {
        while(element.parentElement) {
            if(element.parentElement.matches(selector)) {
                return element.parentElement;
            }
            element = element.parentElement // gán lại để tìm ra ngoài
        }
    }


    var validatorRules = {
        required: function(value){
            if(typeof value === 'string') {
            return value.trim() ? undefined : 'Vui lòng nhập trường này!'
            }
            return value ? undefined : 'Vui lòng nhập trường này!'
        },
        email: function(value){
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : 'Trường này phải là email!'
        },
        min: function(min){
            return function(value) {
                return value.length >= min ? undefined : `Vui lòng nhập tối thiểu ${min} ký tự!`
            }
        },
        max: function(max){
            return function(value) {
                return value.length >= max ? undefined : `Vui lòng nhập tối đa ${max} ký tự!`
            }
        }
    };

    // Lấy ra form element trong DOM theo `formSelector`
   var formElement = document.querySelector(formSelector); 


   // Chỉ xử lý khi có element trong DOM.
   if(formElement) {

        var inputs = formElement.querySelectorAll('[name][rules]')
        for(var input of inputs) {

            var rules = input.getAttribute('rules').split('|') // chia một chuỗi thành mảng có các chuỗi con
            for(var rule of rules) {

                var ruleInfo;
                var isRuleHasValue = rule.includes(':');
                if (isRuleHasValue) {
                    var ruleInfo = rule.split(':')
                    rule = ruleInfo[0] // chạy và gán min
                    // console.log(validatorRules[rule](ruleInfo[1]))
                }
                var ruleFunc = validatorRules[rule];
                if(isRuleHasValue) {
                    ruleFunc = ruleFunc(ruleInfo[1]) // chạy và gán value (số 6)
                }
                // console.log(rule)
                if(Array.isArray(formRules[input.name])) {
                    formRules[input.name].push(ruleFunc) // khi nó là 1 mảng thì đẩy ruleFunc vào
                } else {
                    formRules[input.name] = [ruleFunc] 
                    // ban đầu formRules không phải là 1 mảng trả cho nó 1 mảng rỗng, bên trong gán cho nó các func trả về ở validatorRules
                }

            }


            // Lắng nghe sự kiện đẻ validate(blur, change) 

            input.onblur = handleValidate;
            input.oninput = handleClearError;
        }
        // Hàm thực hiện validate
        function handleValidate(event) {
            var rules = formRules[event.target.name];
            // console.log(formRules[event.target.name]);
            var errorMessage;
            
            for(var rule of rules) {
                errorMessage = rule(event.target.value);
                if(errorMessage) {
                    break;
                } 
            }
            // console.log(errorMessage)
            // nếu có lỗi thì hiển thị message lỗi ra UI
            if(errorMessage) {
                // console.log(event.target)
                var formGroup = getParent(event.target, '.form-group');
                // console.log(formGroup)
                if(formGroup) {
                    formGroup.classList.add('invalid') // add class invalid vào cùng dong vs from-group
                    var formMessage = formGroup.querySelector('.form-message') 
                    if(formMessage) {
                        formMessage.innerHTML = errorMessage;
                    }
                }
            }
            return !errorMessage
        }

        // hàm clear message lỗi
        function handleClearError(event) {
                var formGroup = getParent(event.target, '.form-group');
                if(formGroup.classList.contains('invalid')) {
                    formGroup.classList.remove('invalid') 
                    var formMessage = formGroup.querySelector('.form-message')

                    if(formMessage) {
                        formMessage.innerHTML = '';
                    }
                }
        }
        // console.log(formRules)
   }
   // Xủ lý hành vi submit form
   formElement.onsubmit = function(event) {
       event.preventDefault(); // bỏ hành vi submit mặc định 
    
        var inputs = formElement.querySelectorAll('[name][rules]');
        var isValid = true;

        for(var input of inputs) {
            // console.log(input.name)
            if(!handleValidate({target: input})) {// chạy lại và truyền tham số tương ứng, {} là event
                isValid = false;
            } 
        }
        
        // Khi không có lỗi thì submit form
        if(isValid) {
            if(typeof _this.onSubmit === 'function') {

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

                // Gọi lại hàm submit và trả về giá trị của form.
                _this.onSubmit(formValues);
            } else {
                formElement.submit();
            }
        }   
   }

}

