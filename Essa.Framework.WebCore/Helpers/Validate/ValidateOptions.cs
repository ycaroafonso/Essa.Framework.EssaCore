namespace Essa.Framework.WebCore.Helpers.Validate
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    public class ValidateOptions
    {
        public RulesValidate rules { get; set; }

        public ValidateOptions AddRule(string key, RuleItemValidate rule)
        {
            return AddRule(key, rule, "Esse campo é obrigatório.");
        }

        public ValidateOptions AddRule(string key, RuleItemValidate rule, string mensagem)
        {
            rules = rules ?? new RulesValidate();
            rules.Add(key, rule);

            messages = messages ?? new MessagesValidate();
            messages.Add(key, new MessageItemValidate() { required = mensagem });

            return this;
        }

        public ValidateOptions AddRule(string key, Action<RuleItemValidate> ruleItemValidate)
        {
            ruleItemValidate(new RuleItemValidate());
            return this;
        }

        public MessagesValidate messages { get; set; }


        public JRaw highlight { get; set; } = new JRaw(@"function(element) {
            $(element).closest('.form-group').addClass('has-error');
        }");

        public JRaw unhighlight { get; set; } = new JRaw(@"function(element) {
            $(element).closest('.form-group').removeClass('has-error');
        }");

        public string errorElement { get; set; } = "span";
        public string errorClass { get; set; } = "help-block";
        public JRaw errorPlacement { get; set; } = new JRaw(@"function(error, element) {
            if(element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.appendTo(element.parent());
            }
        }");

        public JRaw submitHandler { get; set; }
        public ValidateOptions setSubmitHandler(string valor)
        {
            submitHandler = new JRaw(valor);
            return this;
        }

        public string lang { get; set; } = "pt-BR";

        [DefaultValue(true)]
        public bool onclick { get; set; } = true;


        /// <summary>
        /// function(errorMap, errorList)
        /// </summary>
        public JRaw showErrors { get; set; }
    }

    public class RulesValidate : Dictionary<string, RuleItemValidate>
    {
    }


    public class RuleItemValidate
    {
        public int minlength { get; set; }
        public int maxlength { get; set; }
        public bool required { get; set; }

        [DefaultValue(false)]
        public bool number { get; set; } = false;

        public int min { get; set; }
    }


    public class MessagesValidate : Dictionary<string, MessageItemValidate>
    {
    }

    public class MessageItemValidate
    {
        public string required { get; set; }
    }

}
