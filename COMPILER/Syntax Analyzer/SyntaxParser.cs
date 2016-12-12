using System.IO;

using Core.Library;

namespace Syntax_Analyzer {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    public class SyntaxParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public SyntaxParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public SyntaxParser(TextReader input, SyntaxAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new SyntaxTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_START_PROGRAM,
                                            "Prod_StartProgram");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_PROGRAM, 1, 1);
            alt.AddToken((int) SyntaxConstants.DIE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PROGRAM,
                                            "Prod_program");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL, 0, 1);
            alt.AddToken((int) SyntaxConstants.LEAD, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKDEF, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_GLOBAL,
                                            "Prod_global");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_CHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_GLOBAL_CHOICE,
                                            "Prod_global_choice");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LET_GLOBAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ARRAY, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_TASK, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DATATYPE,
                                            "Prod_datatype");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LET_GLOBAL,
                                            "Prod_let_global");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LET, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUES,
                                            "Prod_values");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARDEC,
                                            "Prod_vardec");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARDTYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARDTYPE,
                                            "Prod_vardtype");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_INT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_INT, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_DOUBLE, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_DOUBLE, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_CHAR, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_CHAR, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_STRING, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_STRING, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_BOOLEAN, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_BOOLEAN, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_INT,
                                            "Prod_varinitINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_INT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_DOUBLE,
                                            "Prod_varinitDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_CHAR,
                                            "Prod_varinitCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE_CHAR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_STRING,
                                            "Prod_varinitSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_BOOLEAN,
                                            "Prod_varinitBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE_BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARTAIL_INT,
                                            "Prod_vartailINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_INT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_INT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARTAIL_DOUBLE,
                                            "Prod_vartailDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_DOUBLE, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_DOUBLE, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARTAIL_CHAR,
                                            "Prod_vartailCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_CHAR, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_CHAR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARTAIL_STRING,
                                            "Prod_vartailSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_STRING, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_STRING, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARTAIL_BOOLEAN,
                                            "Prod_vartailBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_BOOLEAN, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARTAIL_BOOLEAN, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE_CHAR,
                                            "Prod_valueCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE_STRING,
                                            "Prod_valueSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE_BOOLEAN,
                                            "Prod_valueBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ID_TAIL,
                                            "Prod_id_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS_TAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS_TAIL,
                                            "Prod_ids_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ID_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ID_CHOICES,
                                            "Prod_id_choices");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.AT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX_TAIL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASK_PARAM,
                                            "Prod_task_param");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASK_PARAM_TAIL,
                                            "Prod_task_param_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE,
                                            "Prod_value");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUES, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEX,
                                            "Prod_index");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX_VALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEXOP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEXOP,
                                            "Prod_indexop");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ADD_MIN, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ADD_MIN,
                                            "Prod_add_min");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ADD, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MIN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEX_VALUE,
                                            "Prod_index_value");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEX_TAIL,
                                            "Prod_index_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELEMENTS,
                                            "Prod_elements");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELEMENTS_TAIL,
                                            "Prod_elements_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.AT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ARRAY,
                                            "Prod_array");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ARRAY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OF, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SIZE_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_SIZE_TAIL,
                                            "Prod_size_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BY, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASK,
                                            "Prod_task");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TASK, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_TYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAMETERS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_TYPE,
                                            "Prod_return_type");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NULL, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PARAMETERS,
                                            "Prod_parameters");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM_TAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PARAM_TAIL,
                                            "Prod_param_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT,
                                            "Prod_object");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBJECT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_ELEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_VAR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT_ELEM,
                                            "Prod_object_elem");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBJECT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT_ELEM_TAIL,
                                            "Prod_object_elem_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_ELEM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT_VAR,
                                            "Prod_object_var");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_VAR_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT_VAR_TAIL,
                                            "Prod_object_var_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJECT_VAR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATEMENTS,
                                            "Prod_statements");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_FUNCTIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCTIONS,
                                            "Prod_functions");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ARRAY, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBJECT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IO_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_PRE_INCDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CLEAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IF_OTHERWISE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOOPSTATE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ID_STMT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IO_STATEMENT,
                                            "Prod_io_statement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.READ, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SAY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OUTPUT_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OUTPUT_STATEMENT,
                                            "Prod_output_statement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_CHOICES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONCAT,
                                            "Prod_concat");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OUTPUT_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PRE_INCDEC,
                                            "Prod_pre_incdec");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION,
                                            "Prod_option");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OPTION, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS, 1, 1);
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION_CHOICES,
                                            "Prod_option_choices");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION_INT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION_CHAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION_INT,
                                            "Prod_optionINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_INT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION_CHAR,
                                            "Prod_optionCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_CHAR, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION_STRING,
                                            "Prod_optionSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_STRING, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE_INT,
                                            "Prod_stateINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_INT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE_CHAR,
                                            "Prod_stateCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_CHAR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE_STRING,
                                            "Prod_stateSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE_STRING, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DEFAULT,
                                            "Prod_default");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DEFAULT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITIONS,
                                            "Prod_conditions");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NEGATE, 0, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_CHOICES, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITION_CHOICES,
                                            "Prod_condition_choices");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_IDS, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_REL_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_TAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_REL_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_TAIL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITION_TAIL,
                                            "Prod_condition_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_IDS, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITION_IDS,
                                            "Prod_condition_ids");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ID_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OP_TAIL,
                                            "Prod_logOp_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP_CHOICES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OP_CHOICES,
                                            "Prod_logOp_choices");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NEGATE, 0, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITION_CHOICES, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_REL_OP,
                                            "Prod_relOp");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ISEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOTEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GREAT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LEQ, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OP,
                                            "Prod_logOp");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LOGAND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LOGOR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_NEGATE,
                                            "Prod_negate");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IF_OTHERWISE,
                                            "Prod_IfOtherwise");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IF, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OR, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OTHERWISE, 0, 1);
            alt.AddToken((int) SyntaxConstants.ENDIF, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OR,
                                            "Prod_or");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OR, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OTHERWISE,
                                            "Prod_otherwise");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OTHERWISE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONTROL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_COND_LOOP,
                                            "Prod_cond_loop");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_FUNCTIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONTROL, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONTROL,
                                            "Prod_control");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SKIP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOOPSTATE,
                                            "Prod_loopstate");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.UNTIL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.LOOP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DO, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.LOOPIF, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.FOR, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INITIALIZE, 0, 1);
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND, 0, 1);
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDECVAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.LOOP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INITIALIZE,
                                            "Prod_initialize");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_CHOICES,
                                            "Prod_init_choices");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_COND,
                                            "Prod_cond");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_REL_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INCDECVAR,
                                            "Prod_incdecvar");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ID_STMT,
                                            "Prod_id_stmt");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_STMT_TAIL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ID_STMT_TAIL,
                                            "Prod_id_stmt_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS_TAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INITVALUES, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INITVALUES,
                                            "Prod_initvalues");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_NUM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_INT,
                                            "Prod_mathopINT");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INTVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_INT_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_INT_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_DOUBLE,
                                            "Prod_mathopDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLEVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_NUM,
                                            "Prod_mathopNUM");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NUMVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_NUM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_NUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_NUM_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INTVALUE,
                                            "Prod_intvalue");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_EXPR_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLEVALUE,
                                            "Prod_doublevalue");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_EXPR_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_NUMVALUE,
                                            "Prod_numvalue");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_EXPR_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_EXPR_ID,
                                            "Prod_exprID");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_TAIL, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC_NULL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_PRE_INCDEC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_INT_TAIL,
                                            "Prod_mathopINT_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATORS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_INT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_DOUBLE_TAIL,
                                            "Prod_mathopDOUBLE_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATORS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATHOP_NUM_TAIL,
                                            "Prod_mathopNUM_tail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATORS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MATHOP_NUM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPERATORS,
                                            "Prod_operators");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ADD, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MIN, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MUL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DIV, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MOD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INCDEC,
                                            "Prod_incdec");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INCDEC_NULL,
                                            "Prod_incdec_null");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASKDEF,
                                            "Prod_taskdef");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TASK, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKDEF, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_ID,
                                            "Prod_return_id");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.RESPONSE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.RESPONSE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.RESPONSE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.RESPONSE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.RESPONSE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN_BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NULL, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASKBODY,
                                            "Prod_taskbody");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_INT,
                                            "Prod_returnINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_DOUBLE,
                                            "Prod_returnDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_CHAR,
                                            "Prod_returnCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_STRING,
                                            "Prod_returnSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN_BOOLEAN,
                                            "Prod_returnBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURNTAIL,
                                            "Prod_returntail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ELEMENTS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
