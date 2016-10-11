using System;
using System.IO;
using System.Collections.Generic;
using Core.Library;

using TokenLibrary;

namespace Syntax_Analyzer
{
    public class SyntaxInitializer : SyntaxAnalyzer
    {
        public string production = "";
        Node currparent = null;
        List<Node> prevparent = new List<Node>();
        public override void Enter(Node node)
        {
            string name = node.GetName();
            if (name.Contains("Prod_"))
            {
                node.SetParent(currparent);
                name = name.Substring(5);

                if(currparent != null)
                {
                    production += "Enter: <" + name + "> Parent: " + currparent.GetName() + "\n";
                }
                else
                {
                    production += "Enter: <" + name + ">\n";
                }
                prevparent.Add(currparent);
                currparent = node;
            }
            else
            {
                node.SetParent(currparent);
                production += "Enter: " + name + " Parent: " + currparent.GetName() + "\n";
            }
            switch (node.Id)
            {
                case (int)SyntaxConstants.TASK:
                    EnterTask((Token)node);
                    break;
                case (int)SyntaxConstants.LEAD:
                    EnterLead((Token)node);
                    break;
                case (int)SyntaxConstants.START:
                    EnterStart((Token)node);
                    break;
                case (int)SyntaxConstants.END:
                    EnterEnd((Token)node);
                    break;
                case (int)SyntaxConstants.VAR:
                    EnterVar((Token)node);
                    break;
                case (int)SyntaxConstants.ID:
                    EnterId((Token)node);
                    break;
                case (int)SyntaxConstants.AS:
                    EnterAs((Token)node);
                    break;
                case (int)SyntaxConstants.LET:
                    EnterLet((Token)node);
                    break;
                case (int)SyntaxConstants.OBJECT:
                    EnterObject((Token)node);
                    break;
                case (int)SyntaxConstants.OF:
                    EnterOf((Token)node);
                    break;
                case (int)SyntaxConstants.BY:
                    EnterBy((Token)node);
                    break;
                case (int)SyntaxConstants.IS:
                    EnterIs((Token)node);
                    break;
                case (int)SyntaxConstants.CLEAR:
                    EnterClear((Token)node);
                    break;
                case (int)SyntaxConstants.READ:
                    EnterRead((Token)node);
                    break;
                case (int)SyntaxConstants.SAY:
                    EnterSay((Token)node);
                    break;
                case (int)SyntaxConstants.SKIP:
                    EnterSkip((Token)node);
                    break;
                case (int)SyntaxConstants.STOP:
                    EnterStop((Token)node);
                    break;
                case (int)SyntaxConstants.IF:
                    EnterIf((Token)node);
                    break;
                case (int)SyntaxConstants.OR:
                    EnterOr((Token)node);
                    break;
                case (int)SyntaxConstants.OTHERWISE:
                    EnterOtherwise((Token)node);
                    break;
                case (int)SyntaxConstants.OPTION:
                    EnterOption((Token)node);
                    break;
                case (int)SyntaxConstants.STATE:
                    EnterState((Token)node);
                    break;
                case (int)SyntaxConstants.DEFAULT:
                    EnterDefault((Token)node);
                    break;
                case (int)SyntaxConstants.UNTIL:
                    EnterUntil((Token)node);
                    break;
                case (int)SyntaxConstants.LOOP:
                    EnterLoop((Token)node);
                    break;
                case (int)SyntaxConstants.LOOPIF:
                    EnterLoopif((Token)node);
                    break;
                case (int)SyntaxConstants.DO:
                    EnterDo((Token)node);
                    break;
                case (int)SyntaxConstants.FOR:
                    EnterFor((Token)node);
                    break;
                case (int)SyntaxConstants.RESPONSE:
                    EnterResponse((Token)node);
                    break;
                case (int)SyntaxConstants.ENDIF:
                    EnterEndif((Token)node);
                    break;
                case (int)SyntaxConstants.INT:
                    EnterInt((Token)node);
                    break;
                case (int)SyntaxConstants.DOUBLE:
                    EnterDouble((Token)node);
                    break;
                case (int)SyntaxConstants.CHAR:
                    EnterChar((Token)node);
                    break;
                case (int)SyntaxConstants.STRING:
                    EnterString((Token)node);
                    break;
                case (int)SyntaxConstants.NULL:
                    EnterNull((Token)node);
                    break;
                case (int)SyntaxConstants.ARRAY:
                    EnterArray((Token)node);
                    break;
                case (int)SyntaxConstants.BOOLEAN:
                    EnterBoolean((Token)node);
                    break;
                case (int)SyntaxConstants.INTLIT:
                    EnterIntlit((Token)node);
                    break;
                case (int)SyntaxConstants.DOUBLELIT:
                    EnterDoublelit((Token)node);
                    break;
                case (int)SyntaxConstants.CHARLIT:
                    EnterCharlit((Token)node);
                    break;
                case (int)SyntaxConstants.STRINGLIT:
                    EnterStringlit((Token)node);
                    break;
                case (int)SyntaxConstants.BOOLLIT:
                    EnterBoollit((Token)node);
                    break;
                case (int)SyntaxConstants.COL:
                    EnterCol((Token)node);
                    break;
                case (int)SyntaxConstants.SEM:
                    EnterSem((Token)node);
                    break;
                case (int)SyntaxConstants.DIE:
                    EnterDie((Token)node);
                    break;
                case (int)SyntaxConstants.PER:
                    EnterPer((Token)node);
                    break;
                case (int)SyntaxConstants.OP:
                    EnterOp((Token)node);
                    break;
                case (int)SyntaxConstants.CP:
                    EnterCp((Token)node);
                    break;
                case (int)SyntaxConstants.OB:
                    EnterOb((Token)node);
                    break;
                case (int)SyntaxConstants.CB:
                    EnterCb((Token)node);
                    break;
                case (int)SyntaxConstants.ADD:
                    EnterAdd((Token)node);
                    break;
                case (int)SyntaxConstants.MIN:
                    EnterMin((Token)node);
                    break;
                case (int)SyntaxConstants.MUL:
                    EnterMul((Token)node);
                    break;
                case (int)SyntaxConstants.DIV:
                    EnterDiv((Token)node);
                    break;
                case (int)SyntaxConstants.MOD:
                    EnterMod((Token)node);
                    break;
                case (int)SyntaxConstants.INC:
                    EnterInc((Token)node);
                    break;
                case (int)SyntaxConstants.DEC:
                    EnterDec((Token)node);
                    break;
                case (int)SyntaxConstants.ISEQ:
                    EnterIseq((Token)node);
                    break;
                case (int)SyntaxConstants.NOTEQ:
                    EnterNoteq((Token)node);
                    break;
                case (int)SyntaxConstants.GREAT:
                    EnterGreat((Token)node);
                    break;
                case (int)SyntaxConstants.LESS:
                    EnterLess((Token)node);
                    break;
                case (int)SyntaxConstants.LOGAND:
                    EnterLogand((Token)node);
                    break;
                case (int)SyntaxConstants.LOGOR:
                    EnterLogor((Token)node);
                    break;
                case (int)SyntaxConstants.NOT:
                    EnterNot((Token)node);
                    break;
                case (int)SyntaxConstants.EQ:
                    EnterEq((Token)node);
                    break;
                case (int)SyntaxConstants.COMMA:
                    EnterComma((Token)node);
                    break;
                case (int)SyntaxConstants.AT:
                    EnterAt((Token)node);
                    break;
                case (int)SyntaxConstants.GEQ:
                    EnterGeq((Token)node);
                    break;
                case (int)SyntaxConstants.LEQ:
                    EnterLeq((Token)node);
                    break;
                case (int)SyntaxConstants.PROD_START_PROGRAM:
                    EnterProdStartProgram((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_PROGRAM:
                    EnterProdProgram((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_GLOBAL:
                    EnterProdGlobal((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_GLOBAL_CHOICE:
                    EnterProdGlobalChoice((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DTYPE:
                    EnterProdDtype((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OBJECT:
                    EnterProdObject((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OBJDEC_CHOICE:
                    EnterProdObjdecChoice((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR:
                    EnterProdVar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OBJVAR:
                    EnterProdObjvar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARNAME:
                    EnterProdVarname((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARNAMES:
                    EnterProdVarnames((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TASK:
                    EnterProdTask((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN:
                    EnterProdReturn((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TPARAM:
                    EnterProdTparam((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TPARAMS:
                    EnterProdTparams((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_ARRAY:
                    EnterProdArray((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_SIZE:
                    EnterProdSize((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_SIZES:
                    EnterProdSizes((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARLET:
                    EnterProdVarlet((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARDEC:
                    EnterProdVardec((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR_INT:
                    EnterProdVarInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INIT_INT:
                    EnterProdInitInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR_DOUBLE:
                    EnterProdVarDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INIT_DOUBLE:
                    EnterProdInitDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR_CHAR:
                    EnterProdVarChar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INIT_CHAR:
                    EnterProdInitChar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR_STRING:
                    EnterProdVarString((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INIT_STRING:
                    EnterProdInitString((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VAR_BOOLEAN:
                    EnterProdVarBoolean((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INIT_BOOLEAN:
                    EnterProdInitBoolean((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS1:
                    EnterProdIds1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS2:
                    EnterProdIds2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS3:
                    EnterProdIds3((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS4:
                    EnterProdIds4((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS5:
                    EnterProdIds5((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS1_TAIL:
                    EnterProdIds1Tail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS2_TAIL:
                    EnterProdIds2Tail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS3_TAIL:
                    EnterProdIds3Tail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS4_TAIL:
                    EnterProdIds4Tail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDS5_TAIL:
                    EnterProdIds5Tail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE1:
                    EnterProdValue1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE2:
                    EnterProdValue2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE3:
                    EnterProdValue3((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE4:
                    EnterProdValue4((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE5:
                    EnterProdValue5((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_NUMVALUE:
                    EnterProdNumvalue((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_NUMELEMENT:
                    EnterProdNumelement((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPERATIONS1:
                    EnterProdOperations1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OP_INT:
                    EnterProdOpInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OP1:
                    EnterProdOp1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DOUBLEVALUE:
                    EnterProdDoublevalue((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPERATIONS2:
                    EnterProdOperations2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OP_DOUBLE:
                    EnterProdOpDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OP2:
                    EnterProdOp2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_MATH_OP:
                    EnterProdMathOp((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INCDEC:
                    EnterProdIncdec((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RELOP1:
                    EnterProdRelop1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_LOGOP1:
                    EnterProdLogop1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_LOGOP2:
                    EnterProdLogop2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_BODY:
                    EnterProdBody((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_STATEMENTS:
                    EnterProdStatements((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_FUNCTIONS:
                    EnterProdFunctions((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_ID_CHOICES:
                    EnterProdIdChoices((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_SUBELEMENT_CHOICE:
                    EnterProdSubelementChoice((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT:
                    EnterProdVarinit((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT_INT:
                    EnterProdVarinitInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT_DOUBLE:
                    EnterProdVarinitDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT_CHAR:
                    EnterProdVarinitChar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT_STRING:
                    EnterProdVarinitString((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VARINIT_BOOLEAN:
                    EnterProdVarinitBoolean((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INT:
                    EnterProdInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INTCHOICES:
                    EnterProdIntchoices((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INTCHOICE1:
                    EnterProdIntchoice1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INTCHOICE2:
                    EnterProdIntchoice2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DOUBLE:
                    EnterProdDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DOUBLECHOICES:
                    EnterProdDoublechoices((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DOUBLECHOICE1:
                    EnterProdDoublechoice1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DOUBLECHOICE2:
                    EnterProdDoublechoice2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CHAR:
                    EnterProdChar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_STRING:
                    EnterProdString((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_BOOLEAN:
                    EnterProdBoolean((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TASK_ID:
                    EnterProdTaskId((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_PARAM:
                    EnterProdParam((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_PARAMS:
                    EnterProdParams((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_VALUE:
                    EnterProdValue((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IO_STATEMENT:
                    EnterProdIoStatement((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INPUT:
                    EnterProdInput((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OUTPUT:
                    EnterProdOutput((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INPUT_STATEMENT:
                    EnterProdInputStatement((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONCAT:
                    EnterProdConcat((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONCAT_VALUE:
                    EnterProdConcatValue((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_SUBELEMENT:
                    EnterProdSubelement((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INPUT_ID:
                    EnterProdInputId((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_MULTI:
                    EnterProdMulti((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INDEX:
                    EnterProdIndex((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IF_OTHERWISE:
                    EnterProdIfOtherwise((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OR:
                    EnterProdOr((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OTHERWISE:
                    EnterProdOtherwise((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_COND_LOOP:
                    EnterProdCondLoop((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONTROL:
                    EnterProdControl((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONDITIONS:
                    EnterProdConditions((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONDITIONSCHOICE:
                    EnterProdConditionschoice((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_MULTICONDS:
                    EnterProdMulticonds((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDSCHOICE:
                    EnterProdIdschoice((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDSCHOICE1:
                    EnterProdIdschoice1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_IDSBODY:
                    EnterProdIdsbody((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_CONDS_TAIL:
                    EnterProdCondsTail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_LOG_OPS:
                    EnterProdLogOps((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_REL_OPS:
                    EnterProdRelOps((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RELOP_NUM:
                    EnterProdRelopNum((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RELOP_TEXT:
                    EnterProdRelopText((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_NUMVAL:
                    EnterProdNumval((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPTION:
                    EnterProdOption((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPTIONTAILS:
                    EnterProdOptiontails((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPTIONTAIL1:
                    EnterProdOptiontail1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPTIONTAIL2:
                    EnterProdOptiontail2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_OPTIONTAIL3:
                    EnterProdOptiontail3((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_STATE1:
                    EnterProdState1((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_STATE2:
                    EnterProdState2((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_STATE3:
                    EnterProdState3((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_DEFAULT:
                    EnterProdDefault((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INCDECVAR:
                    EnterProdIncdecvar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_LOOPSTATE:
                    EnterProdLoopstate((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_INITIALIZE:
                    EnterProdInitialize((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_COND:
                    EnterProdCond((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TASKDEF:
                    EnterProdTaskdef((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURNTYPE:
                    EnterProdReturntype((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TASKBODY:
                    EnterProdTaskbody((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_TASKBODYTAIL:
                    EnterProdTaskbodytail((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN_INT:
                    EnterProdReturnInt((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN_DOUBLE:
                    EnterProdReturnDouble((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN_CHAR:
                    EnterProdReturnChar((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN_STRING:
                    EnterProdReturnString((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURN_BOOLEAN:
                    EnterProdReturnBoolean((Production)node);
                    break;
                case (int)SyntaxConstants.PROD_RETURNTAIL:
                    EnterProdReturntail((Production)node);
                    break;
            }
        }
        public override Node Exit(Node node)
        {
            if(currparent == node)
            {
                currparent = prevparent[prevparent.Count-1];
                prevparent.RemoveAt(prevparent.Count - 1);
            }
            string name = node.GetName();
            if (name.Contains("Prod_"))
            {
                name = name.Substring(5);
                if(currparent != null)
                production += "Exit: <" + name + "> Parent: " + currparent.GetName() + "\n";
                else
                    production += "Exit: <" + name + ">\n";
            }
            else
            {
                //if (currparent != null)
                //    production += "Exit: " + name + " Parent: " + currparent.GetName() + "\n";
                //else
                //    production += "Exit: " + name + "\n";
            }
            switch (node.Id)
            {
                case (int)SyntaxConstants.TASK:
                    return ExitTask((Token)node);
                case (int)SyntaxConstants.LEAD:
                    return ExitLead((Token)node);
                case (int)SyntaxConstants.START:
                    return ExitStart((Token)node);
                case (int)SyntaxConstants.END:
                    return ExitEnd((Token)node);
                case (int)SyntaxConstants.VAR:
                    return ExitVar((Token)node);
                case (int)SyntaxConstants.ID:
                    return ExitId((Token)node);
                case (int)SyntaxConstants.AS:
                    return ExitAs((Token)node);
                case (int)SyntaxConstants.LET:
                    return ExitLet((Token)node);
                case (int)SyntaxConstants.OBJECT:
                    return ExitObject((Token)node);
                case (int)SyntaxConstants.OF:
                    return ExitOf((Token)node);
                case (int)SyntaxConstants.BY:
                    return ExitBy((Token)node);
                case (int)SyntaxConstants.IS:
                    return ExitIs((Token)node);
                case (int)SyntaxConstants.CLEAR:
                    return ExitClear((Token)node);
                case (int)SyntaxConstants.READ:
                    return ExitRead((Token)node);
                case (int)SyntaxConstants.SAY:
                    return ExitSay((Token)node);
                case (int)SyntaxConstants.SKIP:
                    return ExitSkip((Token)node);
                case (int)SyntaxConstants.STOP:
                    return ExitStop((Token)node);
                case (int)SyntaxConstants.IF:
                    return ExitIf((Token)node);
                case (int)SyntaxConstants.OR:
                    return ExitOr((Token)node);
                case (int)SyntaxConstants.OTHERWISE:
                    return ExitOtherwise((Token)node);
                case (int)SyntaxConstants.OPTION:
                    return ExitOption((Token)node);
                case (int)SyntaxConstants.STATE:
                    return ExitState((Token)node);
                case (int)SyntaxConstants.DEFAULT:
                    return ExitDefault((Token)node);
                case (int)SyntaxConstants.UNTIL:
                    return ExitUntil((Token)node);
                case (int)SyntaxConstants.LOOP:
                    return ExitLoop((Token)node);
                case (int)SyntaxConstants.LOOPIF:
                    return ExitLoopif((Token)node);
                case (int)SyntaxConstants.DO:
                    return ExitDo((Token)node);
                case (int)SyntaxConstants.FOR:
                    return ExitFor((Token)node);
                case (int)SyntaxConstants.RESPONSE:
                    return ExitResponse((Token)node);
                case (int)SyntaxConstants.ENDIF:
                    return ExitEndif((Token)node);
                case (int)SyntaxConstants.INT:
                    return ExitInt((Token)node);
                case (int)SyntaxConstants.DOUBLE:
                    return ExitDouble((Token)node);
                case (int)SyntaxConstants.CHAR:
                    return ExitChar((Token)node);
                case (int)SyntaxConstants.STRING:
                    return ExitString((Token)node);
                case (int)SyntaxConstants.NULL:
                    return ExitNull((Token)node);
                case (int)SyntaxConstants.ARRAY:
                    return ExitArray((Token)node);
                case (int)SyntaxConstants.BOOLEAN:
                    return ExitBoolean((Token)node);
                case (int)SyntaxConstants.INTLIT:
                    return ExitIntlit((Token)node);
                case (int)SyntaxConstants.DOUBLELIT:
                    return ExitDoublelit((Token)node);
                case (int)SyntaxConstants.CHARLIT:
                    return ExitCharlit((Token)node);
                case (int)SyntaxConstants.STRINGLIT:
                    return ExitStringlit((Token)node);
                case (int)SyntaxConstants.BOOLLIT:
                    return ExitBoollit((Token)node);
                case (int)SyntaxConstants.COL:
                    return ExitCol((Token)node);
                case (int)SyntaxConstants.SEM:
                    return ExitSem((Token)node);
                case (int)SyntaxConstants.DIE:
                    return ExitDie((Token)node);
                case (int)SyntaxConstants.PER:
                    return ExitPer((Token)node);
                case (int)SyntaxConstants.OP:
                    return ExitOp((Token)node);
                case (int)SyntaxConstants.CP:
                    return ExitCp((Token)node);
                case (int)SyntaxConstants.OB:
                    return ExitOb((Token)node);
                case (int)SyntaxConstants.CB:
                    return ExitCb((Token)node);
                case (int)SyntaxConstants.ADD:
                    return ExitAdd((Token)node);
                case (int)SyntaxConstants.MIN:
                    return ExitMin((Token)node);
                case (int)SyntaxConstants.MUL:
                    return ExitMul((Token)node);
                case (int)SyntaxConstants.DIV:
                    return ExitDiv((Token)node);
                case (int)SyntaxConstants.MOD:
                    return ExitMod((Token)node);
                case (int)SyntaxConstants.INC:
                    return ExitInc((Token)node);
                case (int)SyntaxConstants.DEC:
                    return ExitDec((Token)node);
                case (int)SyntaxConstants.ISEQ:
                    return ExitIseq((Token)node);
                case (int)SyntaxConstants.NOTEQ:
                    return ExitNoteq((Token)node);
                case (int)SyntaxConstants.GREAT:
                    return ExitGreat((Token)node);
                case (int)SyntaxConstants.LESS:
                    return ExitLess((Token)node);
                case (int)SyntaxConstants.LOGAND:
                    return ExitLogand((Token)node);
                case (int)SyntaxConstants.LOGOR:
                    return ExitLogor((Token)node);
                case (int)SyntaxConstants.NOT:
                    return ExitNot((Token)node);
                case (int)SyntaxConstants.EQ:
                    return ExitEq((Token)node);
                case (int)SyntaxConstants.COMMA:
                    return ExitComma((Token)node);
                case (int)SyntaxConstants.AT:
                    return ExitAt((Token)node);
                case (int)SyntaxConstants.GEQ:
                    return ExitGeq((Token)node);
                case (int)SyntaxConstants.LEQ:
                    return ExitLeq((Token)node);
                case (int)SyntaxConstants.PROD_START_PROGRAM:
                    return ExitProdStartProgram((Production)node);
                case (int)SyntaxConstants.PROD_PROGRAM:
                    return ExitProdProgram((Production)node);
                case (int)SyntaxConstants.PROD_GLOBAL:
                    return ExitProdGlobal((Production)node);
                case (int)SyntaxConstants.PROD_GLOBAL_CHOICE:
                    return ExitProdGlobalChoice((Production)node);
                case (int)SyntaxConstants.PROD_DTYPE:
                    return ExitProdDtype((Production)node);
                case (int)SyntaxConstants.PROD_OBJECT:
                    return ExitProdObject((Production)node);
                case (int)SyntaxConstants.PROD_OBJDEC_CHOICE:
                    return ExitProdObjdecChoice((Production)node);
                case (int)SyntaxConstants.PROD_VAR:
                    return ExitProdVar((Production)node);
                case (int)SyntaxConstants.PROD_OBJVAR:
                    return ExitProdObjvar((Production)node);
                case (int)SyntaxConstants.PROD_VARNAME:
                    return ExitProdVarname((Production)node);
                case (int)SyntaxConstants.PROD_VARNAMES:
                    return ExitProdVarnames((Production)node);
                case (int)SyntaxConstants.PROD_TASK:
                    return ExitProdTask((Production)node);
                case (int)SyntaxConstants.PROD_RETURN:
                    return ExitProdReturn((Production)node);
                case (int)SyntaxConstants.PROD_TPARAM:
                    return ExitProdTparam((Production)node);
                case (int)SyntaxConstants.PROD_TPARAMS:
                    return ExitProdTparams((Production)node);
                case (int)SyntaxConstants.PROD_ARRAY:
                    return ExitProdArray((Production)node);
                case (int)SyntaxConstants.PROD_SIZE:
                    return ExitProdSize((Production)node);
                case (int)SyntaxConstants.PROD_SIZES:
                    return ExitProdSizes((Production)node);
                case (int)SyntaxConstants.PROD_VARLET:
                    return ExitProdVarlet((Production)node);
                case (int)SyntaxConstants.PROD_VARDEC:
                    return ExitProdVardec((Production)node);
                case (int)SyntaxConstants.PROD_VAR_INT:
                    return ExitProdVarInt((Production)node);
                case (int)SyntaxConstants.PROD_INIT_INT:
                    return ExitProdInitInt((Production)node);
                case (int)SyntaxConstants.PROD_VAR_DOUBLE:
                    return ExitProdVarDouble((Production)node);
                case (int)SyntaxConstants.PROD_INIT_DOUBLE:
                    return ExitProdInitDouble((Production)node);
                case (int)SyntaxConstants.PROD_VAR_CHAR:
                    return ExitProdVarChar((Production)node);
                case (int)SyntaxConstants.PROD_INIT_CHAR:
                    return ExitProdInitChar((Production)node);
                case (int)SyntaxConstants.PROD_VAR_STRING:
                    return ExitProdVarString((Production)node);
                case (int)SyntaxConstants.PROD_INIT_STRING:
                    return ExitProdInitString((Production)node);
                case (int)SyntaxConstants.PROD_VAR_BOOLEAN:
                    return ExitProdVarBoolean((Production)node);
                case (int)SyntaxConstants.PROD_INIT_BOOLEAN:
                    return ExitProdInitBoolean((Production)node);
                case (int)SyntaxConstants.PROD_IDS1:
                    return ExitProdIds1((Production)node);
                case (int)SyntaxConstants.PROD_IDS2:
                    return ExitProdIds2((Production)node);
                case (int)SyntaxConstants.PROD_IDS3:
                    return ExitProdIds3((Production)node);
                case (int)SyntaxConstants.PROD_IDS4:
                    return ExitProdIds4((Production)node);
                case (int)SyntaxConstants.PROD_IDS5:
                    return ExitProdIds5((Production)node);
                case (int)SyntaxConstants.PROD_IDS1_TAIL:
                    return ExitProdIds1Tail((Production)node);
                case (int)SyntaxConstants.PROD_IDS2_TAIL:
                    return ExitProdIds2Tail((Production)node);
                case (int)SyntaxConstants.PROD_IDS3_TAIL:
                    return ExitProdIds3Tail((Production)node);
                case (int)SyntaxConstants.PROD_IDS4_TAIL:
                    return ExitProdIds4Tail((Production)node);
                case (int)SyntaxConstants.PROD_IDS5_TAIL:
                    return ExitProdIds5Tail((Production)node);
                case (int)SyntaxConstants.PROD_VALUE1:
                    return ExitProdValue1((Production)node);
                case (int)SyntaxConstants.PROD_VALUE2:
                    return ExitProdValue2((Production)node);
                case (int)SyntaxConstants.PROD_VALUE3:
                    return ExitProdValue3((Production)node);
                case (int)SyntaxConstants.PROD_VALUE4:
                    return ExitProdValue4((Production)node);
                case (int)SyntaxConstants.PROD_VALUE5:
                    return ExitProdValue5((Production)node);
                case (int)SyntaxConstants.PROD_NUMVALUE:
                    return ExitProdNumvalue((Production)node);
                case (int)SyntaxConstants.PROD_NUMELEMENT:
                    return ExitProdNumelement((Production)node);
                case (int)SyntaxConstants.PROD_OPERATIONS1:
                    return ExitProdOperations1((Production)node);
                case (int)SyntaxConstants.PROD_OP_INT:
                    return ExitProdOpInt((Production)node);
                case (int)SyntaxConstants.PROD_OP1:
                    return ExitProdOp1((Production)node);
                case (int)SyntaxConstants.PROD_DOUBLEVALUE:
                    return ExitProdDoublevalue((Production)node);
                case (int)SyntaxConstants.PROD_OPERATIONS2:
                    return ExitProdOperations2((Production)node);
                case (int)SyntaxConstants.PROD_OP_DOUBLE:
                    return ExitProdOpDouble((Production)node);
                case (int)SyntaxConstants.PROD_OP2:
                    return ExitProdOp2((Production)node);
                case (int)SyntaxConstants.PROD_MATH_OP:
                    return ExitProdMathOp((Production)node);
                case (int)SyntaxConstants.PROD_INCDEC:
                    return ExitProdIncdec((Production)node);
                case (int)SyntaxConstants.PROD_RELOP1:
                    return ExitProdRelop1((Production)node);
                case (int)SyntaxConstants.PROD_LOGOP1:
                    return ExitProdLogop1((Production)node);
                case (int)SyntaxConstants.PROD_LOGOP2:
                    return ExitProdLogop2((Production)node);
                case (int)SyntaxConstants.PROD_BODY:
                    return ExitProdBody((Production)node);
                case (int)SyntaxConstants.PROD_STATEMENTS:
                    return ExitProdStatements((Production)node);
                case (int)SyntaxConstants.PROD_FUNCTIONS:
                    return ExitProdFunctions((Production)node);
                case (int)SyntaxConstants.PROD_ID_CHOICES:
                    return ExitProdIdChoices((Production)node);
                case (int)SyntaxConstants.PROD_SUBELEMENT_CHOICE:
                    return ExitProdSubelementChoice((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT:
                    return ExitProdVarinit((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT_INT:
                    return ExitProdVarinitInt((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT_DOUBLE:
                    return ExitProdVarinitDouble((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT_CHAR:
                    return ExitProdVarinitChar((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT_STRING:
                    return ExitProdVarinitString((Production)node);
                case (int)SyntaxConstants.PROD_VARINIT_BOOLEAN:
                    return ExitProdVarinitBoolean((Production)node);
                case (int)SyntaxConstants.PROD_INT:
                    return ExitProdInt((Production)node);
                case (int)SyntaxConstants.PROD_INTCHOICES:
                    return ExitProdIntchoices((Production)node);
                case (int)SyntaxConstants.PROD_INTCHOICE1:
                    return ExitProdIntchoice1((Production)node);
                case (int)SyntaxConstants.PROD_INTCHOICE2:
                    return ExitProdIntchoice2((Production)node);
                case (int)SyntaxConstants.PROD_DOUBLE:
                    return ExitProdDouble((Production)node);
                case (int)SyntaxConstants.PROD_DOUBLECHOICES:
                    return ExitProdDoublechoices((Production)node);
                case (int)SyntaxConstants.PROD_DOUBLECHOICE1:
                    return ExitProdDoublechoice1((Production)node);
                case (int)SyntaxConstants.PROD_DOUBLECHOICE2:
                    return ExitProdDoublechoice2((Production)node);
                case (int)SyntaxConstants.PROD_CHAR:
                    return ExitProdChar((Production)node);
                case (int)SyntaxConstants.PROD_STRING:
                    return ExitProdString((Production)node);
                case (int)SyntaxConstants.PROD_BOOLEAN:
                    return ExitProdBoolean((Production)node);
                case (int)SyntaxConstants.PROD_TASK_ID:
                    return ExitProdTaskId((Production)node);
                case (int)SyntaxConstants.PROD_PARAM:
                    return ExitProdParam((Production)node);
                case (int)SyntaxConstants.PROD_PARAMS:
                    return ExitProdParams((Production)node);
                case (int)SyntaxConstants.PROD_VALUE:
                    return ExitProdValue((Production)node);
                case (int)SyntaxConstants.PROD_IO_STATEMENT:
                    return ExitProdIoStatement((Production)node);
                case (int)SyntaxConstants.PROD_INPUT:
                    return ExitProdInput((Production)node);
                case (int)SyntaxConstants.PROD_OUTPUT:
                    return ExitProdOutput((Production)node);
                case (int)SyntaxConstants.PROD_INPUT_STATEMENT:
                    return ExitProdInputStatement((Production)node);
                case (int)SyntaxConstants.PROD_CONCAT:
                    return ExitProdConcat((Production)node);
                case (int)SyntaxConstants.PROD_CONCAT_VALUE:
                    return ExitProdConcatValue((Production)node);
                case (int)SyntaxConstants.PROD_SUBELEMENT:
                    return ExitProdSubelement((Production)node);
                case (int)SyntaxConstants.PROD_INPUT_ID:
                    return ExitProdInputId((Production)node);
                case (int)SyntaxConstants.PROD_MULTI:
                    return ExitProdMulti((Production)node);
                case (int)SyntaxConstants.PROD_INDEX:
                    return ExitProdIndex((Production)node);
                case (int)SyntaxConstants.PROD_IF_OTHERWISE:
                    return ExitProdIfOtherwise((Production)node);
                case (int)SyntaxConstants.PROD_OR:
                    return ExitProdOr((Production)node);
                case (int)SyntaxConstants.PROD_OTHERWISE:
                    return ExitProdOtherwise((Production)node);
                case (int)SyntaxConstants.PROD_COND_LOOP:
                    return ExitProdCondLoop((Production)node);
                case (int)SyntaxConstants.PROD_CONTROL:
                    return ExitProdControl((Production)node);
                case (int)SyntaxConstants.PROD_CONDITIONS:
                    return ExitProdConditions((Production)node);
                case (int)SyntaxConstants.PROD_CONDITIONSCHOICE:
                    return ExitProdConditionschoice((Production)node);
                case (int)SyntaxConstants.PROD_MULTICONDS:
                    return ExitProdMulticonds((Production)node);
                case (int)SyntaxConstants.PROD_IDSCHOICE:
                    return ExitProdIdschoice((Production)node);
                case (int)SyntaxConstants.PROD_IDSCHOICE1:
                    return ExitProdIdschoice1((Production)node);
                case (int)SyntaxConstants.PROD_IDSBODY:
                    return ExitProdIdsbody((Production)node);
                case (int)SyntaxConstants.PROD_CONDS_TAIL:
                    return ExitProdCondsTail((Production)node);
                case (int)SyntaxConstants.PROD_LOG_OPS:
                    return ExitProdLogOps((Production)node);
                case (int)SyntaxConstants.PROD_REL_OPS:
                    return ExitProdRelOps((Production)node);
                case (int)SyntaxConstants.PROD_RELOP_NUM:
                    return ExitProdRelopNum((Production)node);
                case (int)SyntaxConstants.PROD_RELOP_TEXT:
                    return ExitProdRelopText((Production)node);
                case (int)SyntaxConstants.PROD_NUMVAL:
                    return ExitProdNumval((Production)node);
                case (int)SyntaxConstants.PROD_OPTION:
                    return ExitProdOption((Production)node);
                case (int)SyntaxConstants.PROD_OPTIONTAILS:
                    return ExitProdOptiontails((Production)node);
                case (int)SyntaxConstants.PROD_OPTIONTAIL1:
                    return ExitProdOptiontail1((Production)node);
                case (int)SyntaxConstants.PROD_OPTIONTAIL2:
                    return ExitProdOptiontail2((Production)node);
                case (int)SyntaxConstants.PROD_OPTIONTAIL3:
                    return ExitProdOptiontail3((Production)node);
                case (int)SyntaxConstants.PROD_STATE1:
                    return ExitProdState1((Production)node);
                case (int)SyntaxConstants.PROD_STATE2:
                    return ExitProdState2((Production)node);
                case (int)SyntaxConstants.PROD_STATE3:
                    return ExitProdState3((Production)node);
                case (int)SyntaxConstants.PROD_DEFAULT:
                    return ExitProdDefault((Production)node);
                case (int)SyntaxConstants.PROD_INCDECVAR:
                    return ExitProdIncdecvar((Production)node);
                case (int)SyntaxConstants.PROD_LOOPSTATE:
                    return ExitProdLoopstate((Production)node);
                case (int)SyntaxConstants.PROD_INITIALIZE:
                    return ExitProdInitialize((Production)node);
                case (int)SyntaxConstants.PROD_COND:
                    return ExitProdCond((Production)node);
                case (int)SyntaxConstants.PROD_TASKDEF:
                    return ExitProdTaskdef((Production)node);
                case (int)SyntaxConstants.PROD_RETURNTYPE:
                    return ExitProdReturntype((Production)node);
                case (int)SyntaxConstants.PROD_TASKBODY:
                    return ExitProdTaskbody((Production)node);
                case (int)SyntaxConstants.PROD_TASKBODYTAIL:
                    return ExitProdTaskbodytail((Production)node);
                case (int)SyntaxConstants.PROD_RETURN_INT:
                    return ExitProdReturnInt((Production)node);
                case (int)SyntaxConstants.PROD_RETURN_DOUBLE:
                    return ExitProdReturnDouble((Production)node);
                case (int)SyntaxConstants.PROD_RETURN_CHAR:
                    return ExitProdReturnChar((Production)node);
                case (int)SyntaxConstants.PROD_RETURN_STRING:
                    return ExitProdReturnString((Production)node);
                case (int)SyntaxConstants.PROD_RETURN_BOOLEAN:
                    return ExitProdReturnBoolean((Production)node);
                case (int)SyntaxConstants.PROD_RETURNTAIL:
                    return ExitProdReturntail((Production)node);
            }
            return node;
        }

        public override Node Analyze(Node node)
        {
            return base.Analyze(node);
        }

        public override Node Analyze(Node node, ParserLogException log)
        {
            return base.Analyze(node, log);
        }

        public ErrorClass errors = new ErrorClass();
        public string Start(List<TokensClass> tokens)
        {
            string tokenstream = "";
            string result;
            int line = 1;
            int linejump = 0;
            foreach (var t in tokens)
            {
                if (t.getLines() != line)
                {
                    linejump = t.getLines() - line;
                    line = t.getLines();
                    for (int i = 0; i < linejump; i++)
                    {
                        tokenstream += "\n";
                    }
                }
                tokenstream += t.getTokens() + " ";
            }
            tokenstream = tokenstream.TrimEnd();

            Parser p;
            p = CreateParser(tokenstream);

            try
            {
                Node n = p.Analyzer.Analyze(p.Parse());
                //p.Parse();
                Fail("parsing succeeded");
                result = "Syntax Analyzer Succeeded...";
            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
                result = e.Message;
            }
            catch (ParserLogException e)
            {
                string message = "Expected ";
                errors.setColumn(e.GetError(0).Column);
                errors.setLines(e.GetError(0).Line);
                if (e.GetError(0).Details != null && e.GetError(0).Details.Count != 1)
                {
                    message = "Expected one of ";
                }
                foreach (var item in e.GetError(0).Details)
                {
                    message += item + ", ";     
                }
                message += ".";
                if(message == "Expected \")\", .")
                {
                    message = "Expected one of \")\", \"==\", \"!=\", \">=\", \"<=\", \">\", \"<\".";
                }
                errors.setErrorMessage(message);
                errors.setType(e.GetError(0).Type.ToString());
                result = e.Message;

            }
            return result;
        }

        private Parser CreateParser(string input)
        {
            Parser parser = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), this);
                parser.Prepare();

            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
            }
            return parser;
        }

        protected void Fail(string message)
        {
            if (message != "parsing succeeded")
                throw new Exception(message);
        }

      

    }
}
