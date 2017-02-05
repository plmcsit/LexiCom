namespace Syntax_Analyzer
{
    public class SyntaxProductions
    {
        public string GetProductionName(string prod)
        {
            string production = prod;
            if (production.Contains("prod_"))
            {
                switch (prod)
                {
                    // Productions
                    case "prod_startprogram":
                        production = "prod_Start_Program"; break;
                    case "prod_varinit_int":
                        production = "prod_varinitINT"; break;
                    case "prod_varinit_double":
                        production = "prod_varinitDOUBLE"; break;
                    case "prod_varinit_char":
                        production = "prod_varinitCHAR"; break;
                    case "prod_varinit_string":
                        production = "prod_varinitSTRING"; break;
                    case "prod_varinit_boolean":
                        production = "prod_varinitBOOLEAN"; break;
                    case "prod_vartail_int":
                        production = "prod_vartailINT"; break;
                    case "prod_vartail_double":
                        production = "prod_vartailDOUBLE"; break;
                    case "prod_vartail_char":
                        production = "prod_vartailCHAR"; break;
                    case "prod_vartail_string":
                        production = "prod_vartailSTRING"; break;
                    case "prod_vartail_boolean":
                        production = "prod_vartailBOOLEAN"; break;
                    case "prod_value_char":
                        production = "prod_valueCHAR"; break;
                    case "prod_value_string":
                        production = "prod_valueSTRING"; break;
                    case "prod_value_boolean":
                        production = "prod_valueBOOLEAN"; break;
                    case "prod_option_int":
                        production = "prod_optionINT"; break;
                    case "prod_option_string":
                        production = "prod_optionSTRING"; break;
                    case "prod_option_char":
                        production = "prod_optionCHAR"; break;
                    case "prod_state_int":
                        production = "prod_stateINT"; break;
                    case "prod_state_string":
                        production = "prod_stateSTRING"; break;
                    case "prod_state_char":
                        production = "prod_stateCHAR"; break;
                    case "prod_log_op":
                        production = "prod_logOp"; break;
                    case "prod_log_op_tail":
                        production = "prod_logOp_tail"; break;
                    case "prod_log_op_choices":
                        production = "prod_logOp_choices"; break;
                    case "prod_rel_op":
                        production = "prod_relOp"; break;
                    case "prod_if_otherwise":
                        production = "prod_IfOtherwise"; break;
                    case "prod_mathop_int":
                        production = "prod_mathopINT"; break;
                    case "prod_mathop_double":
                        production = "prod_mathopDOUBLE"; break;
                    case "prod_mathop_num":
                        production = "prod_mathopNUM"; break;
                    case "prod_mathop_int_tail":
                        production = "prod_mathopINT_tail"; break;
                    case "prod_mathop_double_tail":
                        production = "prod_mathopDOUBLE_tail"; break;
                    case "prod_mathop_num_tail":
                        production = "prod_mathopNUM_tail"; break;
                    case "prod_return_int":
                        production = "prod_returnINT"; break;
                    case "prod_return_double":
                        production = "prod_returnDOUBLE"; break;
                    case "prod_return_string":
                        production = "prod_returnSTRING"; break;
                    case "prod_return_char":
                        production = "prod_returnCHAR"; break;
                    case "prod_return_boolean":
                        production = "prod_returnBOOLEAN"; break;
                }
            }
            else
            {
                switch (prod)
                {

                    // Tokens
                    case "task":
                        production = "Task"; break;
                    case "lead":
                        production = "Lead"; break;
                    case "start":
                        production = "Start"; break;
                    case "end":
                        production = "End"; break;
                    case "var":
                        production = "Var"; break;
                    case "id":
                        production = "id"; break;
                    case "as":
                        production = "as"; break;
                    case "let":
                        production = "Let"; break;
                    case "object":
                        production = "Object"; break;
                    case "of":
                        production = "of"; break;
                    case "by":
                        production = "by"; break;
                    case "is":
                        production = "is"; break;
                    case "clear":
                        production = "Clear"; break;
                    case "read":
                        production = "Read"; break;
                    case "say":
                        production = "Say"; break;
                    case "skip":
                        production = "Skip"; break;
                    case "stop":
                        production = "Stop"; break;
                    case "if":
                        production = "If"; break;
                    case "or":
                        production = "Or"; break;
                    case "otherwise":
                        production = "Otherwise"; break;
                    case "option":
                        production = "Option"; break;
                    case "state":
                        production = "State"; break;
                    case "default":
                        production = "Default"; break;
                    case "until":
                        production = "Until"; break;
                    case "loop":
                        production = "Loop"; break;
                    case "loopif":
                        production = "LoopIf"; break;
                    case "do":
                        production = "Do"; break;
                    case "for":
                        production = "For"; break;
                    case "response":
                        production = "Response"; break;
                    case "endif":
                        production = "EndIf"; break;
                    case "int":
                        production = "Int"; break;
                    case "double":
                        production = "Double"; break;
                    case "char":
                        production = "Char"; break;
                    case "string":
                        production = "String"; break;
                    case "null":
                        production = "Null"; break;
                    case "array":
                        production = "Array"; break;
                    case "boolean":
                        production = "Boolean"; break;
                    case "intlit":
                        production = "intlit"; break;
                    case "charlit":
                        production = "charlit"; break;
                    case "doublelit":
                        production = "doublelit"; break;
                    case "stringlit":
                        production = "stringlit"; break;
                    case "boollit":
                        production = "boollit"; break;
                    case "col":
                        production = ":"; break;
                    case "sem":
                        production = ";"; break;
                    case "die":
                        production = "#"; break;
                    case "per":
                        production = "."; break;
                    case "op":
                        production = "("; break;
                    case "cp":
                        production = ")"; break;
                    case "ob":
                        production = "["; break;
                    case "cb":
                        production = "]"; break;
                    case "add":
                        production = "+"; break;
                    case "min":
                        production = "-"; break;
                    case "mul":
                        production = "*"; break;
                    case "div":
                        production = "/"; break;
                    case "mod":
                        production = "%"; break;
                    case "inc":
                        production = "++"; break;
                    case "dec":
                        production = "--"; break;
                    case "iseq":
                        production = "=="; break;
                    case "noteq":
                        production = "!="; break;
                    case "great":
                        production = ">"; break;
                    case "less":
                        production = "<"; break;
                    case "logand":
                        production = "&&"; break;
                    case "logor":
                        production = "||"; break;
                    case "not":
                        production = "!"; break;
                    case "eq":
                        production = "="; break;
                    case "comma":
                        production = ","; break;
                    case "at":
                        production = "@"; break;
                    case "geq":
                        production = ">="; break;
                    case "leq":
                        production = "<="; break;
                    case "whitespace":
                        break;
                }
            }

            return production;
        }
    }
}
