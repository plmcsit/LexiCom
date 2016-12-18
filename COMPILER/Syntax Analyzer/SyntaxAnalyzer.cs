using Core.Library;
namespace Syntax_Analyzer {

    /**
     * <remarks>A class providing callback methods for the
     * parser.</remarks>
     */
    public abstract class SyntaxAnalyzer : Analyzer {

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override void Enter(Node node) {
            switch (node.Id) {
            case (int) SyntaxConstants.TASK:
                EnterTask((Token) node);
                break;
            case (int) SyntaxConstants.LEAD:
                EnterLead((Token) node);
                break;
            case (int) SyntaxConstants.START:
                EnterStart((Token) node);
                break;
            case (int) SyntaxConstants.END:
                EnterEnd((Token) node);
                break;
            case (int) SyntaxConstants.VAR:
                EnterVar((Token) node);
                break;
            case (int) SyntaxConstants.ID:
                EnterId((Token) node);
                break;
            case (int) SyntaxConstants.AS:
                EnterAs((Token) node);
                break;
            case (int) SyntaxConstants.LET:
                EnterLet((Token) node);
                break;
            case (int) SyntaxConstants.OBJECT:
                EnterObject((Token) node);
                break;
            case (int) SyntaxConstants.OF:
                EnterOf((Token) node);
                break;
            case (int) SyntaxConstants.BY:
                EnterBy((Token) node);
                break;
            case (int) SyntaxConstants.IS:
                EnterIs((Token) node);
                break;
            case (int) SyntaxConstants.CLEAR:
                EnterClear((Token) node);
                break;
            case (int) SyntaxConstants.READ:
                EnterRead((Token) node);
                break;
            case (int) SyntaxConstants.SAY:
                EnterSay((Token) node);
                break;
            case (int) SyntaxConstants.SKIP:
                EnterSkip((Token) node);
                break;
            case (int) SyntaxConstants.STOP:
                EnterStop((Token) node);
                break;
            case (int) SyntaxConstants.IF:
                EnterIf((Token) node);
                break;
            case (int) SyntaxConstants.OR:
                EnterOr((Token) node);
                break;
            case (int) SyntaxConstants.OTHERWISE:
                EnterOtherwise((Token) node);
                break;
            case (int) SyntaxConstants.OPTION:
                EnterOption((Token) node);
                break;
            case (int) SyntaxConstants.STATE:
                EnterState((Token) node);
                break;
            case (int) SyntaxConstants.DEFAULT:
                EnterDefault((Token) node);
                break;
            case (int) SyntaxConstants.UNTIL:
                EnterUntil((Token) node);
                break;
            case (int) SyntaxConstants.LOOP:
                EnterLoop((Token) node);
                break;
            case (int) SyntaxConstants.LOOPIF:
                EnterLoopif((Token) node);
                break;
            case (int) SyntaxConstants.DO:
                EnterDo((Token) node);
                break;
            case (int) SyntaxConstants.FOR:
                EnterFor((Token) node);
                break;
            case (int) SyntaxConstants.RESPONSE:
                EnterResponse((Token) node);
                break;
            case (int) SyntaxConstants.ENDIF:
                EnterEndif((Token) node);
                break;
            case (int) SyntaxConstants.INT:
                EnterInt((Token) node);
                break;
            case (int) SyntaxConstants.DOUBLE:
                EnterDouble((Token) node);
                break;
            case (int) SyntaxConstants.CHAR:
                EnterChar((Token) node);
                break;
            case (int) SyntaxConstants.STRING:
                EnterString((Token) node);
                break;
            case (int) SyntaxConstants.NULL:
                EnterNull((Token) node);
                break;
            case (int) SyntaxConstants.ARRAY:
                EnterArray((Token) node);
                break;
            case (int) SyntaxConstants.BOOLEAN:
                EnterBoolean((Token) node);
                break;
            case (int) SyntaxConstants.INTLIT:
                EnterIntlit((Token) node);
                break;
            case (int) SyntaxConstants.DOUBLELIT:
                EnterDoublelit((Token) node);
                break;
            case (int) SyntaxConstants.CHARLIT:
                EnterCharlit((Token) node);
                break;
            case (int) SyntaxConstants.STRINGLIT:
                EnterStringlit((Token) node);
                break;
            case (int) SyntaxConstants.BOOLLIT:
                EnterBoollit((Token) node);
                break;
            case (int) SyntaxConstants.COL:
                EnterCol((Token) node);
                break;
            case (int) SyntaxConstants.SEM:
                EnterSem((Token) node);
                break;
            case (int) SyntaxConstants.DIE:
                EnterDie((Token) node);
                break;
            case (int) SyntaxConstants.PER:
                EnterPer((Token) node);
                break;
            case (int) SyntaxConstants.OP:
                EnterOp((Token) node);
                break;
            case (int) SyntaxConstants.CP:
                EnterCp((Token) node);
                break;
            case (int) SyntaxConstants.OB:
                EnterOb((Token) node);
                break;
            case (int) SyntaxConstants.CB:
                EnterCb((Token) node);
                break;
            case (int) SyntaxConstants.ADD:
                EnterAdd((Token) node);
                break;
            case (int) SyntaxConstants.MIN:
                EnterMin((Token) node);
                break;
            case (int) SyntaxConstants.MUL:
                EnterMul((Token) node);
                break;
            case (int) SyntaxConstants.DIV:
                EnterDiv((Token) node);
                break;
            case (int) SyntaxConstants.MOD:
                EnterMod((Token) node);
                break;
            case (int) SyntaxConstants.INC:
                EnterInc((Token) node);
                break;
            case (int) SyntaxConstants.DEC:
                EnterDec((Token) node);
                break;
            case (int) SyntaxConstants.ISEQ:
                EnterIseq((Token) node);
                break;
            case (int) SyntaxConstants.NOTEQ:
                EnterNoteq((Token) node);
                break;
            case (int) SyntaxConstants.GREAT:
                EnterGreat((Token) node);
                break;
            case (int) SyntaxConstants.LESS:
                EnterLess((Token) node);
                break;
            case (int) SyntaxConstants.LOGAND:
                EnterLogand((Token) node);
                break;
            case (int) SyntaxConstants.LOGOR:
                EnterLogor((Token) node);
                break;
            case (int) SyntaxConstants.NOT:
                EnterNot((Token) node);
                break;
            case (int) SyntaxConstants.EQ:
                EnterEq((Token) node);
                break;
            case (int) SyntaxConstants.COMMA:
                EnterComma((Token) node);
                break;
            case (int) SyntaxConstants.AT:
                EnterAt((Token) node);
                break;
            case (int) SyntaxConstants.GEQ:
                EnterGeq((Token) node);
                break;
            case (int) SyntaxConstants.LEQ:
                EnterLeq((Token) node);
                break;
            case (int) SyntaxConstants.PROD_START_PROGRAM:
                EnterProdStartProgram((Production) node);
                break;
            case (int) SyntaxConstants.PROD_PROGRAM:
                EnterProdProgram((Production) node);
                break;
            case (int) SyntaxConstants.PROD_GLOBAL:
                EnterProdGlobal((Production) node);
                break;
            case (int) SyntaxConstants.PROD_GLOBAL_CHOICE:
                EnterProdGlobalChoice((Production) node);
                break;
            case (int) SyntaxConstants.PROD_DATATYPE:
                EnterProdDatatype((Production) node);
                break;
            case (int) SyntaxConstants.PROD_LET_GLOBAL:
                EnterProdLetGlobal((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VALUES:
                EnterProdValues((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARDEC:
                EnterProdVardec((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARDTYPE:
                EnterProdVardtype((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_INT:
                EnterProdVarinitInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_DOUBLE:
                EnterProdVarinitDouble((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_CHAR:
                EnterProdVarinitChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_STRING:
                EnterProdVarinitString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_BOOLEAN:
                EnterProdVarinitBoolean((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_INT:
                EnterProdVartailInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_DOUBLE:
                EnterProdVartailDouble((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_CHAR:
                EnterProdVartailChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_STRING:
                EnterProdVartailString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_BOOLEAN:
                EnterProdVartailBoolean((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VALUE_CHAR:
                EnterProdValueChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VALUE_STRING:
                EnterProdValueString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VALUE_BOOLEAN:
                EnterProdValueBoolean((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ID_TAIL:
                EnterProdIdTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_IDS_TAIL:
                EnterProdIdsTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ID_CHOICES:
                EnterProdIdChoices((Production) node);
                break;
            case (int) SyntaxConstants.PROD_TASK_PARAM:
                EnterProdTaskParam((Production) node);
                break;
            case (int) SyntaxConstants.PROD_TASK_PARAM_TAIL:
                EnterProdTaskParamTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_VALUE:
                EnterProdValue((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INDEX:
                EnterProdIndex((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INDEXOP:
                EnterProdIndexop((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ADD_MIN:
                EnterProdAddMin((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INDEX_VALUE:
                EnterProdIndexValue((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INDEX_TAIL:
                EnterProdIndexTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ELEMENTS:
                EnterProdElements((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ELEMENTS_TAIL:
                EnterProdElementsTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ARRAY:
                EnterProdArray((Production) node);
                break;
            case (int) SyntaxConstants.PROD_SIZE_TAIL:
                EnterProdSizeTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_TASK:
                EnterProdTask((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_TYPE:
                EnterProdReturnType((Production) node);
                break;
            case (int) SyntaxConstants.PROD_PARAMETERS:
                EnterProdParameters((Production) node);
                break;
            case (int) SyntaxConstants.PROD_PARAM_TAIL:
                EnterProdParamTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OBJECT:
                EnterProdObject((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_ELEM:
                EnterProdObjectElem((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL:
                EnterProdObjectElemTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_VAR:
                EnterProdObjectVar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_VAR_TAIL:
                EnterProdObjectVarTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_STATEMENTS:
                EnterProdStatements((Production) node);
                break;
            case (int) SyntaxConstants.PROD_FUNCTIONS:
                EnterProdFunctions((Production) node);
                break;
            case (int) SyntaxConstants.PROD_IO_STATEMENT:
                EnterProdIoStatement((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OUTPUT_STATEMENT:
                EnterProdOutputStatement((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONCAT:
                EnterProdConcat((Production) node);
                break;
            case (int) SyntaxConstants.PROD_PRE_INCDEC:
                EnterProdPreIncdec((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPTION:
                EnterProdOption((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPTION_CHOICES:
                EnterProdOptionChoices((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPTION_INT:
                EnterProdOptionInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPTION_CHAR:
                EnterProdOptionChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPTION_STRING:
                EnterProdOptionString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_STATE_INT:
                EnterProdStateInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_STATE_CHAR:
                EnterProdStateChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_STATE_STRING:
                EnterProdStateString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_DEFAULT:
                EnterProdDefault((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONDITIONS:
                EnterProdConditions((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_CHOICES:
                EnterProdConditionChoices((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_TAIL:
                EnterProdConditionTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_IDS:
                EnterProdConditionIds((Production) node);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP_TAIL:
                EnterProdLogOpTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP_CHOICES:
                EnterProdLogOpChoices((Production) node);
                break;
            case (int) SyntaxConstants.PROD_REL_OP:
                EnterProdRelOp((Production) node);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP:
                EnterProdLogOp((Production) node);
                break;
            case (int) SyntaxConstants.PROD_NEGATE:
                EnterProdNegate((Production) node);
                break;
            case (int) SyntaxConstants.PROD_IF_OTHERWISE:
                EnterProdIfOtherwise((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OR:
                EnterProdOr((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OTHERWISE:
                EnterProdOtherwise((Production) node);
                break;
            case (int) SyntaxConstants.PROD_COND_LOOP:
                EnterProdCondLoop((Production) node);
                break;
            case (int) SyntaxConstants.PROD_CONTROL:
                EnterProdControl((Production) node);
                break;
            case (int) SyntaxConstants.PROD_LOOPSTATE:
                EnterProdLoopstate((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INITIALIZE:
                EnterProdInitialize((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INIT_CHOICES:
                EnterProdInitChoices((Production) node);
                break;
            case (int) SyntaxConstants.PROD_COND:
                EnterProdCond((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INCDECVAR:
                EnterProdIncdecvar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ID_STMT:
                EnterProdIdStmt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_ID_STMT_TAIL:
                EnterProdIdStmtTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INITVALUES:
                EnterProdInitvalues((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_INT:
                EnterProdMathopInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE:
                EnterProdMathopDouble((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_NUM:
                EnterProdMathopNum((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INTVALUE:
                EnterProdIntvalue((Production) node);
                break;
            case (int) SyntaxConstants.PROD_DOUBLEVALUE:
                EnterProdDoublevalue((Production) node);
                break;
            case (int) SyntaxConstants.PROD_NUMVALUE:
                EnterProdNumvalue((Production) node);
                break;
            case (int) SyntaxConstants.PROD_EXPR_ID:
                EnterProdExprId((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_INT_TAIL:
                EnterProdMathopIntTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL:
                EnterProdMathopDoubleTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_NUM_TAIL:
                EnterProdMathopNumTail((Production) node);
                break;
            case (int) SyntaxConstants.PROD_OPERATORS:
                EnterProdOperators((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INCDEC:
                EnterProdIncdec((Production) node);
                break;
            case (int) SyntaxConstants.PROD_INCDEC_NULL:
                EnterProdIncdecNull((Production) node);
                break;
            case (int) SyntaxConstants.PROD_TASKDEF:
                EnterProdTaskdef((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_ID:
                EnterProdReturnId((Production) node);
                break;
            case (int) SyntaxConstants.PROD_TASKBODY:
                EnterProdTaskbody((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_INT:
                EnterProdReturnInt((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_DOUBLE:
                EnterProdReturnDouble((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_CHAR:
                EnterProdReturnChar((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_STRING:
                EnterProdReturnString((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURN_BOOLEAN:
                EnterProdReturnBoolean((Production) node);
                break;
            case (int) SyntaxConstants.PROD_RETURNTAIL:
                EnterProdReturntail((Production) node);
                break;
            }
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override Node Exit(Node node) {
            switch (node.Id) {
            case (int) SyntaxConstants.TASK:
                return ExitTask((Token) node);
            case (int) SyntaxConstants.LEAD:
                return ExitLead((Token) node);
            case (int) SyntaxConstants.START:
                return ExitStart((Token) node);
            case (int) SyntaxConstants.END:
                return ExitEnd((Token) node);
            case (int) SyntaxConstants.VAR:
                return ExitVar((Token) node);
            case (int) SyntaxConstants.ID:
                return ExitId((Token) node);
            case (int) SyntaxConstants.AS:
                return ExitAs((Token) node);
            case (int) SyntaxConstants.LET:
                return ExitLet((Token) node);
            case (int) SyntaxConstants.OBJECT:
                return ExitObject((Token) node);
            case (int) SyntaxConstants.OF:
                return ExitOf((Token) node);
            case (int) SyntaxConstants.BY:
                return ExitBy((Token) node);
            case (int) SyntaxConstants.IS:
                return ExitIs((Token) node);
            case (int) SyntaxConstants.CLEAR:
                return ExitClear((Token) node);
            case (int) SyntaxConstants.READ:
                return ExitRead((Token) node);
            case (int) SyntaxConstants.SAY:
                return ExitSay((Token) node);
            case (int) SyntaxConstants.SKIP:
                return ExitSkip((Token) node);
            case (int) SyntaxConstants.STOP:
                return ExitStop((Token) node);
            case (int) SyntaxConstants.IF:
                return ExitIf((Token) node);
            case (int) SyntaxConstants.OR:
                return ExitOr((Token) node);
            case (int) SyntaxConstants.OTHERWISE:
                return ExitOtherwise((Token) node);
            case (int) SyntaxConstants.OPTION:
                return ExitOption((Token) node);
            case (int) SyntaxConstants.STATE:
                return ExitState((Token) node);
            case (int) SyntaxConstants.DEFAULT:
                return ExitDefault((Token) node);
            case (int) SyntaxConstants.UNTIL:
                return ExitUntil((Token) node);
            case (int) SyntaxConstants.LOOP:
                return ExitLoop((Token) node);
            case (int) SyntaxConstants.LOOPIF:
                return ExitLoopif((Token) node);
            case (int) SyntaxConstants.DO:
                return ExitDo((Token) node);
            case (int) SyntaxConstants.FOR:
                return ExitFor((Token) node);
            case (int) SyntaxConstants.RESPONSE:
                return ExitResponse((Token) node);
            case (int) SyntaxConstants.ENDIF:
                return ExitEndif((Token) node);
            case (int) SyntaxConstants.INT:
                return ExitInt((Token) node);
            case (int) SyntaxConstants.DOUBLE:
                return ExitDouble((Token) node);
            case (int) SyntaxConstants.CHAR:
                return ExitChar((Token) node);
            case (int) SyntaxConstants.STRING:
                return ExitString((Token) node);
            case (int) SyntaxConstants.NULL:
                return ExitNull((Token) node);
            case (int) SyntaxConstants.ARRAY:
                return ExitArray((Token) node);
            case (int) SyntaxConstants.BOOLEAN:
                return ExitBoolean((Token) node);
            case (int) SyntaxConstants.INTLIT:
                return ExitIntlit((Token) node);
            case (int) SyntaxConstants.DOUBLELIT:
                return ExitDoublelit((Token) node);
            case (int) SyntaxConstants.CHARLIT:
                return ExitCharlit((Token) node);
            case (int) SyntaxConstants.STRINGLIT:
                return ExitStringlit((Token) node);
            case (int) SyntaxConstants.BOOLLIT:
                return ExitBoollit((Token) node);
            case (int) SyntaxConstants.COL:
                return ExitCol((Token) node);
            case (int) SyntaxConstants.SEM:
                return ExitSem((Token) node);
            case (int) SyntaxConstants.DIE:
                return ExitDie((Token) node);
            case (int) SyntaxConstants.PER:
                return ExitPer((Token) node);
            case (int) SyntaxConstants.OP:
                return ExitOp((Token) node);
            case (int) SyntaxConstants.CP:
                return ExitCp((Token) node);
            case (int) SyntaxConstants.OB:
                return ExitOb((Token) node);
            case (int) SyntaxConstants.CB:
                return ExitCb((Token) node);
            case (int) SyntaxConstants.ADD:
                return ExitAdd((Token) node);
            case (int) SyntaxConstants.MIN:
                return ExitMin((Token) node);
            case (int) SyntaxConstants.MUL:
                return ExitMul((Token) node);
            case (int) SyntaxConstants.DIV:
                return ExitDiv((Token) node);
            case (int) SyntaxConstants.MOD:
                return ExitMod((Token) node);
            case (int) SyntaxConstants.INC:
                return ExitInc((Token) node);
            case (int) SyntaxConstants.DEC:
                return ExitDec((Token) node);
            case (int) SyntaxConstants.ISEQ:
                return ExitIseq((Token) node);
            case (int) SyntaxConstants.NOTEQ:
                return ExitNoteq((Token) node);
            case (int) SyntaxConstants.GREAT:
                return ExitGreat((Token) node);
            case (int) SyntaxConstants.LESS:
                return ExitLess((Token) node);
            case (int) SyntaxConstants.LOGAND:
                return ExitLogand((Token) node);
            case (int) SyntaxConstants.LOGOR:
                return ExitLogor((Token) node);
            case (int) SyntaxConstants.NOT:
                return ExitNot((Token) node);
            case (int) SyntaxConstants.EQ:
                return ExitEq((Token) node);
            case (int) SyntaxConstants.COMMA:
                return ExitComma((Token) node);
            case (int) SyntaxConstants.AT:
                return ExitAt((Token) node);
            case (int) SyntaxConstants.GEQ:
                return ExitGeq((Token) node);
            case (int) SyntaxConstants.LEQ:
                return ExitLeq((Token) node);
            case (int) SyntaxConstants.PROD_START_PROGRAM:
                return ExitProdStartProgram((Production) node);
            case (int) SyntaxConstants.PROD_PROGRAM:
                return ExitProdProgram((Production) node);
            case (int) SyntaxConstants.PROD_GLOBAL:
                return ExitProdGlobal((Production) node);
            case (int) SyntaxConstants.PROD_GLOBAL_CHOICE:
                return ExitProdGlobalChoice((Production) node);
            case (int) SyntaxConstants.PROD_DATATYPE:
                return ExitProdDatatype((Production) node);
            case (int) SyntaxConstants.PROD_LET_GLOBAL:
                return ExitProdLetGlobal((Production) node);
            case (int) SyntaxConstants.PROD_VALUES:
                return ExitProdValues((Production) node);
            case (int) SyntaxConstants.PROD_VARDEC:
                return ExitProdVardec((Production) node);
            case (int) SyntaxConstants.PROD_VARDTYPE:
                return ExitProdVardtype((Production) node);
            case (int) SyntaxConstants.PROD_VARINIT_INT:
                return ExitProdVarinitInt((Production) node);
            case (int) SyntaxConstants.PROD_VARINIT_DOUBLE:
                return ExitProdVarinitDouble((Production) node);
            case (int) SyntaxConstants.PROD_VARINIT_CHAR:
                return ExitProdVarinitChar((Production) node);
            case (int) SyntaxConstants.PROD_VARINIT_STRING:
                return ExitProdVarinitString((Production) node);
            case (int) SyntaxConstants.PROD_VARINIT_BOOLEAN:
                return ExitProdVarinitBoolean((Production) node);
            case (int) SyntaxConstants.PROD_VARTAIL_INT:
                return ExitProdVartailInt((Production) node);
            case (int) SyntaxConstants.PROD_VARTAIL_DOUBLE:
                return ExitProdVartailDouble((Production) node);
            case (int) SyntaxConstants.PROD_VARTAIL_CHAR:
                return ExitProdVartailChar((Production) node);
            case (int) SyntaxConstants.PROD_VARTAIL_STRING:
                return ExitProdVartailString((Production) node);
            case (int) SyntaxConstants.PROD_VARTAIL_BOOLEAN:
                return ExitProdVartailBoolean((Production) node);
            case (int) SyntaxConstants.PROD_VALUE_CHAR:
                return ExitProdValueChar((Production) node);
            case (int) SyntaxConstants.PROD_VALUE_STRING:
                return ExitProdValueString((Production) node);
            case (int) SyntaxConstants.PROD_VALUE_BOOLEAN:
                return ExitProdValueBoolean((Production) node);
            case (int) SyntaxConstants.PROD_ID_TAIL:
                return ExitProdIdTail((Production) node);
            case (int) SyntaxConstants.PROD_IDS_TAIL:
                return ExitProdIdsTail((Production) node);
            case (int) SyntaxConstants.PROD_ID_CHOICES:
                return ExitProdIdChoices((Production) node);
            case (int) SyntaxConstants.PROD_TASK_PARAM:
                return ExitProdTaskParam((Production) node);
            case (int) SyntaxConstants.PROD_TASK_PARAM_TAIL:
                return ExitProdTaskParamTail((Production) node);
            case (int) SyntaxConstants.PROD_VALUE:
                return ExitProdValue((Production) node);
            case (int) SyntaxConstants.PROD_INDEX:
                return ExitProdIndex((Production) node);
            case (int) SyntaxConstants.PROD_INDEXOP:
                return ExitProdIndexop((Production) node);
            case (int) SyntaxConstants.PROD_ADD_MIN:
                return ExitProdAddMin((Production) node);
            case (int) SyntaxConstants.PROD_INDEX_VALUE:
                return ExitProdIndexValue((Production) node);
            case (int) SyntaxConstants.PROD_INDEX_TAIL:
                return ExitProdIndexTail((Production) node);
            case (int) SyntaxConstants.PROD_ELEMENTS:
                return ExitProdElements((Production) node);
            case (int) SyntaxConstants.PROD_ELEMENTS_TAIL:
                return ExitProdElementsTail((Production) node);
            case (int) SyntaxConstants.PROD_ARRAY:
                return ExitProdArray((Production) node);
            case (int) SyntaxConstants.PROD_SIZE_TAIL:
                return ExitProdSizeTail((Production) node);
            case (int) SyntaxConstants.PROD_TASK:
                return ExitProdTask((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_TYPE:
                return ExitProdReturnType((Production) node);
            case (int) SyntaxConstants.PROD_PARAMETERS:
                return ExitProdParameters((Production) node);
            case (int) SyntaxConstants.PROD_PARAM_TAIL:
                return ExitProdParamTail((Production) node);
            case (int) SyntaxConstants.PROD_OBJECT:
                return ExitProdObject((Production) node);
            case (int) SyntaxConstants.PROD_OBJECT_ELEM:
                return ExitProdObjectElem((Production) node);
            case (int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL:
                return ExitProdObjectElemTail((Production) node);
            case (int) SyntaxConstants.PROD_OBJECT_VAR:
                return ExitProdObjectVar((Production) node);
            case (int) SyntaxConstants.PROD_OBJECT_VAR_TAIL:
                return ExitProdObjectVarTail((Production) node);
            case (int) SyntaxConstants.PROD_STATEMENTS:
                return ExitProdStatements((Production) node);
            case (int) SyntaxConstants.PROD_FUNCTIONS:
                return ExitProdFunctions((Production) node);
            case (int) SyntaxConstants.PROD_IO_STATEMENT:
                return ExitProdIoStatement((Production) node);
            case (int) SyntaxConstants.PROD_OUTPUT_STATEMENT:
                return ExitProdOutputStatement((Production) node);
            case (int) SyntaxConstants.PROD_CONCAT:
                return ExitProdConcat((Production) node);
            case (int) SyntaxConstants.PROD_PRE_INCDEC:
                return ExitProdPreIncdec((Production) node);
            case (int) SyntaxConstants.PROD_OPTION:
                return ExitProdOption((Production) node);
            case (int) SyntaxConstants.PROD_OPTION_CHOICES:
                return ExitProdOptionChoices((Production) node);
            case (int) SyntaxConstants.PROD_OPTION_INT:
                return ExitProdOptionInt((Production) node);
            case (int) SyntaxConstants.PROD_OPTION_CHAR:
                return ExitProdOptionChar((Production) node);
            case (int) SyntaxConstants.PROD_OPTION_STRING:
                return ExitProdOptionString((Production) node);
            case (int) SyntaxConstants.PROD_STATE_INT:
                return ExitProdStateInt((Production) node);
            case (int) SyntaxConstants.PROD_STATE_CHAR:
                return ExitProdStateChar((Production) node);
            case (int) SyntaxConstants.PROD_STATE_STRING:
                return ExitProdStateString((Production) node);
            case (int) SyntaxConstants.PROD_DEFAULT:
                return ExitProdDefault((Production) node);
            case (int) SyntaxConstants.PROD_CONDITIONS:
                return ExitProdConditions((Production) node);
            case (int) SyntaxConstants.PROD_CONDITION_CHOICES:
                return ExitProdConditionChoices((Production) node);
            case (int) SyntaxConstants.PROD_CONDITION_TAIL:
                return ExitProdConditionTail((Production) node);
            case (int) SyntaxConstants.PROD_CONDITION_IDS:
                return ExitProdConditionIds((Production) node);
            case (int) SyntaxConstants.PROD_LOG_OP_TAIL:
                return ExitProdLogOpTail((Production) node);
            case (int) SyntaxConstants.PROD_LOG_OP_CHOICES:
                return ExitProdLogOpChoices((Production) node);
            case (int) SyntaxConstants.PROD_REL_OP:
                return ExitProdRelOp((Production) node);
            case (int) SyntaxConstants.PROD_LOG_OP:
                return ExitProdLogOp((Production) node);
            case (int) SyntaxConstants.PROD_NEGATE:
                return ExitProdNegate((Production) node);
            case (int) SyntaxConstants.PROD_IF_OTHERWISE:
                return ExitProdIfOtherwise((Production) node);
            case (int) SyntaxConstants.PROD_OR:
                return ExitProdOr((Production) node);
            case (int) SyntaxConstants.PROD_OTHERWISE:
                return ExitProdOtherwise((Production) node);
            case (int) SyntaxConstants.PROD_COND_LOOP:
                return ExitProdCondLoop((Production) node);
            case (int) SyntaxConstants.PROD_CONTROL:
                return ExitProdControl((Production) node);
            case (int) SyntaxConstants.PROD_LOOPSTATE:
                return ExitProdLoopstate((Production) node);
            case (int) SyntaxConstants.PROD_INITIALIZE:
                return ExitProdInitialize((Production) node);
            case (int) SyntaxConstants.PROD_INIT_CHOICES:
                return ExitProdInitChoices((Production) node);
            case (int) SyntaxConstants.PROD_COND:
                return ExitProdCond((Production) node);
            case (int) SyntaxConstants.PROD_INCDECVAR:
                return ExitProdIncdecvar((Production) node);
            case (int) SyntaxConstants.PROD_ID_STMT:
                return ExitProdIdStmt((Production) node);
            case (int) SyntaxConstants.PROD_ID_STMT_TAIL:
                return ExitProdIdStmtTail((Production) node);
            case (int) SyntaxConstants.PROD_INITVALUES:
                return ExitProdInitvalues((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_INT:
                return ExitProdMathopInt((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE:
                return ExitProdMathopDouble((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_NUM:
                return ExitProdMathopNum((Production) node);
            case (int) SyntaxConstants.PROD_INTVALUE:
                return ExitProdIntvalue((Production) node);
            case (int) SyntaxConstants.PROD_DOUBLEVALUE:
                return ExitProdDoublevalue((Production) node);
            case (int) SyntaxConstants.PROD_NUMVALUE:
                return ExitProdNumvalue((Production) node);
            case (int) SyntaxConstants.PROD_EXPR_ID:
                return ExitProdExprId((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_INT_TAIL:
                return ExitProdMathopIntTail((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL:
                return ExitProdMathopDoubleTail((Production) node);
            case (int) SyntaxConstants.PROD_MATHOP_NUM_TAIL:
                return ExitProdMathopNumTail((Production) node);
            case (int) SyntaxConstants.PROD_OPERATORS:
                return ExitProdOperators((Production) node);
            case (int) SyntaxConstants.PROD_INCDEC:
                return ExitProdIncdec((Production) node);
            case (int) SyntaxConstants.PROD_INCDEC_NULL:
                return ExitProdIncdecNull((Production) node);
            case (int) SyntaxConstants.PROD_TASKDEF:
                return ExitProdTaskdef((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_ID:
                return ExitProdReturnId((Production) node);
            case (int) SyntaxConstants.PROD_TASKBODY:
                return ExitProdTaskbody((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_INT:
                return ExitProdReturnInt((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_DOUBLE:
                return ExitProdReturnDouble((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_CHAR:
                return ExitProdReturnChar((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_STRING:
                return ExitProdReturnString((Production) node);
            case (int) SyntaxConstants.PROD_RETURN_BOOLEAN:
                return ExitProdReturnBoolean((Production) node);
            case (int) SyntaxConstants.PROD_RETURNTAIL:
                return ExitProdReturntail((Production) node);
            }
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public override void Child(Production node, Node child) {
            switch (node.Id) {
            case (int) SyntaxConstants.PROD_START_PROGRAM:
                ChildProdStartProgram(node, child);
                break;
            case (int) SyntaxConstants.PROD_PROGRAM:
                ChildProdProgram(node, child);
                break;
            case (int) SyntaxConstants.PROD_GLOBAL:
                ChildProdGlobal(node, child);
                break;
            case (int) SyntaxConstants.PROD_GLOBAL_CHOICE:
                ChildProdGlobalChoice(node, child);
                break;
            case (int) SyntaxConstants.PROD_DATATYPE:
                ChildProdDatatype(node, child);
                break;
            case (int) SyntaxConstants.PROD_LET_GLOBAL:
                ChildProdLetGlobal(node, child);
                break;
            case (int) SyntaxConstants.PROD_VALUES:
                ChildProdValues(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARDEC:
                ChildProdVardec(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARDTYPE:
                ChildProdVardtype(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_INT:
                ChildProdVarinitInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_DOUBLE:
                ChildProdVarinitDouble(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_CHAR:
                ChildProdVarinitChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_STRING:
                ChildProdVarinitString(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARINIT_BOOLEAN:
                ChildProdVarinitBoolean(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_INT:
                ChildProdVartailInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_DOUBLE:
                ChildProdVartailDouble(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_CHAR:
                ChildProdVartailChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_STRING:
                ChildProdVartailString(node, child);
                break;
            case (int) SyntaxConstants.PROD_VARTAIL_BOOLEAN:
                ChildProdVartailBoolean(node, child);
                break;
            case (int) SyntaxConstants.PROD_VALUE_CHAR:
                ChildProdValueChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_VALUE_STRING:
                ChildProdValueString(node, child);
                break;
            case (int) SyntaxConstants.PROD_VALUE_BOOLEAN:
                ChildProdValueBoolean(node, child);
                break;
            case (int) SyntaxConstants.PROD_ID_TAIL:
                ChildProdIdTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_IDS_TAIL:
                ChildProdIdsTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_ID_CHOICES:
                ChildProdIdChoices(node, child);
                break;
            case (int) SyntaxConstants.PROD_TASK_PARAM:
                ChildProdTaskParam(node, child);
                break;
            case (int) SyntaxConstants.PROD_TASK_PARAM_TAIL:
                ChildProdTaskParamTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_VALUE:
                ChildProdValue(node, child);
                break;
            case (int) SyntaxConstants.PROD_INDEX:
                ChildProdIndex(node, child);
                break;
            case (int) SyntaxConstants.PROD_INDEXOP:
                ChildProdIndexop(node, child);
                break;
            case (int) SyntaxConstants.PROD_ADD_MIN:
                ChildProdAddMin(node, child);
                break;
            case (int) SyntaxConstants.PROD_INDEX_VALUE:
                ChildProdIndexValue(node, child);
                break;
            case (int) SyntaxConstants.PROD_INDEX_TAIL:
                ChildProdIndexTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_ELEMENTS:
                ChildProdElements(node, child);
                break;
            case (int) SyntaxConstants.PROD_ELEMENTS_TAIL:
                ChildProdElementsTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_ARRAY:
                ChildProdArray(node, child);
                break;
            case (int) SyntaxConstants.PROD_SIZE_TAIL:
                ChildProdSizeTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_TASK:
                ChildProdTask(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_TYPE:
                ChildProdReturnType(node, child);
                break;
            case (int) SyntaxConstants.PROD_PARAMETERS:
                ChildProdParameters(node, child);
                break;
            case (int) SyntaxConstants.PROD_PARAM_TAIL:
                ChildProdParamTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_OBJECT:
                ChildProdObject(node, child);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_ELEM:
                ChildProdObjectElem(node, child);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL:
                ChildProdObjectElemTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_VAR:
                ChildProdObjectVar(node, child);
                break;
            case (int) SyntaxConstants.PROD_OBJECT_VAR_TAIL:
                ChildProdObjectVarTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_STATEMENTS:
                ChildProdStatements(node, child);
                break;
            case (int) SyntaxConstants.PROD_FUNCTIONS:
                ChildProdFunctions(node, child);
                break;
            case (int) SyntaxConstants.PROD_IO_STATEMENT:
                ChildProdIoStatement(node, child);
                break;
            case (int) SyntaxConstants.PROD_OUTPUT_STATEMENT:
                ChildProdOutputStatement(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONCAT:
                ChildProdConcat(node, child);
                break;
            case (int) SyntaxConstants.PROD_PRE_INCDEC:
                ChildProdPreIncdec(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPTION:
                ChildProdOption(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPTION_CHOICES:
                ChildProdOptionChoices(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPTION_INT:
                ChildProdOptionInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPTION_CHAR:
                ChildProdOptionChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPTION_STRING:
                ChildProdOptionString(node, child);
                break;
            case (int) SyntaxConstants.PROD_STATE_INT:
                ChildProdStateInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_STATE_CHAR:
                ChildProdStateChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_STATE_STRING:
                ChildProdStateString(node, child);
                break;
            case (int) SyntaxConstants.PROD_DEFAULT:
                ChildProdDefault(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONDITIONS:
                ChildProdConditions(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_CHOICES:
                ChildProdConditionChoices(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_TAIL:
                ChildProdConditionTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONDITION_IDS:
                ChildProdConditionIds(node, child);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP_TAIL:
                ChildProdLogOpTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP_CHOICES:
                ChildProdLogOpChoices(node, child);
                break;
            case (int) SyntaxConstants.PROD_REL_OP:
                ChildProdRelOp(node, child);
                break;
            case (int) SyntaxConstants.PROD_LOG_OP:
                ChildProdLogOp(node, child);
                break;
            case (int) SyntaxConstants.PROD_NEGATE:
                ChildProdNegate(node, child);
                break;
            case (int) SyntaxConstants.PROD_IF_OTHERWISE:
                ChildProdIfOtherwise(node, child);
                break;
            case (int) SyntaxConstants.PROD_OR:
                ChildProdOr(node, child);
                break;
            case (int) SyntaxConstants.PROD_OTHERWISE:
                ChildProdOtherwise(node, child);
                break;
            case (int) SyntaxConstants.PROD_COND_LOOP:
                ChildProdCondLoop(node, child);
                break;
            case (int) SyntaxConstants.PROD_CONTROL:
                ChildProdControl(node, child);
                break;
            case (int) SyntaxConstants.PROD_LOOPSTATE:
                ChildProdLoopstate(node, child);
                break;
            case (int) SyntaxConstants.PROD_INITIALIZE:
                ChildProdInitialize(node, child);
                break;
            case (int) SyntaxConstants.PROD_INIT_CHOICES:
                ChildProdInitChoices(node, child);
                break;
            case (int) SyntaxConstants.PROD_COND:
                ChildProdCond(node, child);
                break;
            case (int) SyntaxConstants.PROD_INCDECVAR:
                ChildProdIncdecvar(node, child);
                break;
            case (int) SyntaxConstants.PROD_ID_STMT:
                ChildProdIdStmt(node, child);
                break;
            case (int) SyntaxConstants.PROD_ID_STMT_TAIL:
                ChildProdIdStmtTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_INITVALUES:
                ChildProdInitvalues(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_INT:
                ChildProdMathopInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE:
                ChildProdMathopDouble(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_NUM:
                ChildProdMathopNum(node, child);
                break;
            case (int) SyntaxConstants.PROD_INTVALUE:
                ChildProdIntvalue(node, child);
                break;
            case (int) SyntaxConstants.PROD_DOUBLEVALUE:
                ChildProdDoublevalue(node, child);
                break;
            case (int) SyntaxConstants.PROD_NUMVALUE:
                ChildProdNumvalue(node, child);
                break;
            case (int) SyntaxConstants.PROD_EXPR_ID:
                ChildProdExprId(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_INT_TAIL:
                ChildProdMathopIntTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL:
                ChildProdMathopDoubleTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_MATHOP_NUM_TAIL:
                ChildProdMathopNumTail(node, child);
                break;
            case (int) SyntaxConstants.PROD_OPERATORS:
                ChildProdOperators(node, child);
                break;
            case (int) SyntaxConstants.PROD_INCDEC:
                ChildProdIncdec(node, child);
                break;
            case (int) SyntaxConstants.PROD_INCDEC_NULL:
                ChildProdIncdecNull(node, child);
                break;
            case (int) SyntaxConstants.PROD_TASKDEF:
                ChildProdTaskdef(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_ID:
                ChildProdReturnId(node, child);
                break;
            case (int) SyntaxConstants.PROD_TASKBODY:
                ChildProdTaskbody(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_INT:
                ChildProdReturnInt(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_DOUBLE:
                ChildProdReturnDouble(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_CHAR:
                ChildProdReturnChar(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_STRING:
                ChildProdReturnString(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURN_BOOLEAN:
                ChildProdReturnBoolean(node, child);
                break;
            case (int) SyntaxConstants.PROD_RETURNTAIL:
                ChildProdReturntail(node, child);
                break;
            }
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterTask(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitTask(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLead(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLead(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStart(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStart(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEnd(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEnd(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterVar(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitVar(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterId(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitId(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAs(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAs(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLet(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLet(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterObject(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitObject(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOf(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOf(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBy(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBy(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterIs(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitIs(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterClear(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitClear(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterRead(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitRead(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSay(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSay(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSkip(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSkip(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStop(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStop(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterIf(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitIf(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOr(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOr(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOtherwise(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOtherwise(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOption(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOption(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterState(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitState(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDefault(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDefault(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterUntil(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitUntil(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoop(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoop(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLoopif(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLoopif(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDo(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDo(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterFor(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitFor(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterResponse(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitResponse(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEndif(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEndif(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterInt(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitInt(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDouble(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDouble(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterChar(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitChar(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterString(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitString(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterNull(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitNull(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterArray(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitArray(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBoolean(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBoolean(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterIntlit(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitIntlit(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDoublelit(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDoublelit(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterCharlit(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitCharlit(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterStringlit(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitStringlit(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterBoollit(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitBoollit(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterCol(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitCol(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterSem(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitSem(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDie(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDie(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterPer(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitPer(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOp(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOp(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterCp(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitCp(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterOb(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitOb(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterCb(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitCb(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAdd(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAdd(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMin(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMin(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMul(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMul(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDiv(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDiv(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterMod(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitMod(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterInc(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitInc(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterDec(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitDec(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterIseq(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitIseq(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterNoteq(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitNoteq(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterGreat(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitGreat(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLess(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLess(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogand(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogand(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLogor(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLogor(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterNot(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitNot(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterEq(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitEq(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterComma(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitComma(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterAt(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitAt(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterGeq(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitGeq(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterLeq(Token node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitLeq(Token node) {
            return node;
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdStartProgram(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdStartProgram(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdStartProgram(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdProgram(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdProgram(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdProgram(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdGlobal(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdGlobal(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdGlobal(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdGlobalChoice(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdGlobalChoice(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdGlobalChoice(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdDatatype(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdDatatype(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdDatatype(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdLetGlobal(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdLetGlobal(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdLetGlobal(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdValues(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdValues(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdValues(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVardec(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVardec(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVardec(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVardtype(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVardtype(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVardtype(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVarinitInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVarinitInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVarinitInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVarinitDouble(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVarinitDouble(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVarinitDouble(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVarinitChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVarinitChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVarinitChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVarinitString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVarinitString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVarinitString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVarinitBoolean(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVarinitBoolean(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVarinitBoolean(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVartailInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVartailInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVartailInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVartailDouble(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVartailDouble(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVartailDouble(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVartailChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVartailChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVartailChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVartailString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVartailString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVartailString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdVartailBoolean(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdVartailBoolean(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdVartailBoolean(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdValueChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdValueChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdValueChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdValueString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdValueString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdValueString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdValueBoolean(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdValueBoolean(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdValueBoolean(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIdTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIdTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIdTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIdsTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIdsTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIdsTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIdChoices(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIdChoices(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIdChoices(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdTaskParam(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdTaskParam(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdTaskParam(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdTaskParamTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdTaskParamTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdTaskParamTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdValue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdValue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdValue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIndex(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIndex(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIndex(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIndexop(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIndexop(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIndexop(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdAddMin(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdAddMin(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdAddMin(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIndexValue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIndexValue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIndexValue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIndexTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIndexTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIndexTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdElements(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdElements(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdElements(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdElementsTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdElementsTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdElementsTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdArray(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdArray(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdArray(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdSizeTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdSizeTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdSizeTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdTask(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdTask(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdTask(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnType(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnType(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnType(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdParameters(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdParameters(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdParameters(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdParamTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdParamTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdParamTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdObject(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdObject(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdObject(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdObjectElem(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdObjectElem(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdObjectElem(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdObjectElemTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdObjectElemTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdObjectElemTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdObjectVar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdObjectVar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdObjectVar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdObjectVarTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdObjectVarTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdObjectVarTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdStatements(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdStatements(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdStatements(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdFunctions(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdFunctions(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdFunctions(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIoStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIoStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIoStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOutputStatement(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOutputStatement(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOutputStatement(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdConcat(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdConcat(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdConcat(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdPreIncdec(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdPreIncdec(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdPreIncdec(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOption(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOption(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOption(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOptionChoices(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOptionChoices(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOptionChoices(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOptionInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOptionInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOptionInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOptionChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOptionChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOptionChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOptionString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOptionString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOptionString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdStateInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdStateInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdStateInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdStateChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdStateChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdStateChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdStateString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdStateString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdStateString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdDefault(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdDefault(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdDefault(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdConditions(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdConditions(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdConditions(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdConditionChoices(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdConditionChoices(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdConditionChoices(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdConditionTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdConditionTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdConditionTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdConditionIds(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdConditionIds(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdConditionIds(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdLogOpTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdLogOpTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdLogOpTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdLogOpChoices(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdLogOpChoices(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdLogOpChoices(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdRelOp(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdRelOp(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdRelOp(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdLogOp(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdLogOp(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdLogOp(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdNegate(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdNegate(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdNegate(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIfOtherwise(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIfOtherwise(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIfOtherwise(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOr(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOr(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOr(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOtherwise(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOtherwise(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOtherwise(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdCondLoop(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdCondLoop(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdCondLoop(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdControl(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdControl(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdControl(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdLoopstate(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdLoopstate(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdLoopstate(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdInitialize(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdInitialize(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdInitialize(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdInitChoices(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdInitChoices(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdInitChoices(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdCond(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdCond(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdCond(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIncdecvar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIncdecvar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIncdecvar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIdStmt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIdStmt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIdStmt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIdStmtTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIdStmtTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIdStmtTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdInitvalues(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdInitvalues(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdInitvalues(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopDouble(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopDouble(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopDouble(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopNum(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopNum(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopNum(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIntvalue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIntvalue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIntvalue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdDoublevalue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdDoublevalue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdDoublevalue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdNumvalue(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdNumvalue(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdNumvalue(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdExprId(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdExprId(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdExprId(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopIntTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopIntTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopIntTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopDoubleTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopDoubleTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopDoubleTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdMathopNumTail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdMathopNumTail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdMathopNumTail(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdOperators(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdOperators(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdOperators(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIncdec(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIncdec(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIncdec(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdIncdecNull(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdIncdecNull(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdIncdecNull(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdTaskdef(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdTaskdef(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdTaskdef(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnId(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnId(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnId(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdTaskbody(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdTaskbody(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdTaskbody(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnInt(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnInt(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnInt(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnDouble(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnDouble(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnDouble(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnChar(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnChar(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnChar(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnString(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnString(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnString(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturnBoolean(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturnBoolean(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturnBoolean(Production node, Node child) {
            node.AddChild(child);
        }

        /**
         * <summary>Called when entering a parse tree node.</summary>
         *
         * <param name='node'>the node being entered</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void EnterProdReturntail(Production node) {
        }

        /**
         * <summary>Called when exiting a parse tree node.</summary>
         *
         * <param name='node'>the node being exited</param>
         *
         * <returns>the node to add to the parse tree, or
         *          null if no parse tree should be created</returns>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual Node ExitProdReturntail(Production node) {
            return node;
        }

        /**
         * <summary>Called when adding a child to a parse tree
         * node.</summary>
         *
         * <param name='node'>the parent node</param>
         * <param name='child'>the child node, or null</param>
         *
         * <exception cref='ParseException'>if the node analysis
         * discovered errors</exception>
         */
        public virtual void ChildProdReturntail(Production node, Node child) {
            node.AddChild(child);
        }
    }
}
