/*
 * SyntaxParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

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
            alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
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
            alt.AddProduction((int) SyntaxConstants.PROD_VARLET, 1, 1);
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

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DTYPE,
                                            "Prod_dtype");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJECT,
                                            "Prod_object");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBJECT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJDEC_CHOICE, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARNAME, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJDEC_CHOICE,
                                            "Prod_objdec_choice");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OBJVAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJDEC_CHOICE, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OBJDEC_CHOICE, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR,
                                            "Prod_var");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OBJVAR,
                                            "Prod_objvar");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBJECT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARNAME,
                                            "Prod_varname");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARNAMES, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARNAMES,
                                            "Prod_varnames");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARNAME, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASK,
                                            "Prod_task");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TASK, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TPARAM, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN,
                                            "Prod_return");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NULL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TPARAM,
                                            "Prod_tparam");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TPARAMS, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TPARAMS,
                                            "Prod_tparams");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TPARAMS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ARRAY,
                                            "Prod_array");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ARRAY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OF, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SIZE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_SIZE,
                                            "Prod_size");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SIZES, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_SIZES,
                                            "Prod_sizes");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BY, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARLET,
                                            "Prod_varlet");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LET, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARDEC,
                                            "Prod_vardec");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR_INT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR_CHAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR_STRING, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VAR_BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR_INT,
                                            "Prod_varINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_INT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_INT,
                                            "Prod_initINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS1, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS1, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR_DOUBLE,
                                            "Prod_varDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_DOUBLE, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_DOUBLE,
                                            "Prod_initDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS2, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR_CHAR,
                                            "Prod_varCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHAR, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_CHAR,
                                            "Prod_initCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE3, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS3, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS3, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR_STRING,
                                            "Prod_varSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_STRING, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_STRING,
                                            "Prod_initSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE4, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS4, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS4, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAR_BOOLEAN,
                                            "Prod_varBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INIT_BOOLEAN, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_BOOLEAN,
                                            "Prod_initBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE5, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS5, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDS5, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS1,
                                            "Prod_ids1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS1_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS2,
                                            "Prod_ids2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS2_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS3,
                                            "Prod_ids3");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS3_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS4,
                                            "Prod_ids4");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS4_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS5,
                                            "Prod_ids5");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS5_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS1_TAIL,
                                            "Prod_ids1_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS2_TAIL,
                                            "Prod_ids2_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS3_TAIL,
                                            "Prod_ids3_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE3, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS3, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS4_TAIL,
                                            "Prod_ids4_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE4, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS4, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDS5_TAIL,
                                            "Prod_ids5_tail");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.IS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE5, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDS5, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE1,
                                            "Prod_value1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NUMVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS1, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE2,
                                            "Prod_value2");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLEVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS2, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE3,
                                            "Prod_value3");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE4,
                                            "Prod_value4");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE5,
                                            "Prod_value5");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_NUMVALUE,
                                            "Prod_numvalue");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NUMELEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_NUMELEMENT,
                                            "Prod_numelement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 0, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPERATIONS1,
                                            "Prod_Operations1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OP_INT,
                                            "Prod_OpInt");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NUMVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS1, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OP1,
                                            "Prod_Op1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP_INT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLEVALUE,
                                            "Prod_doublevalue");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_NUMELEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPERATIONS2,
                                            "Prod_Operations2");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OP_DOUBLE,
                                            "Prod_OpDouble");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLEVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS2, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OP2,
                                            "Prod_Op2");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATH_OP,
                                            "Prod_mathOp");
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

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RELOP1,
                                            "Prod_relop1");
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
            alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LEQ, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOGOP1,
                                            "Prod_logop1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LOGAND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LOGOR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOGOP2,
                                            "Prod_logop2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_BODY,
                                            "Prod_body");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 1, 1);
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
            alt.AddToken((int) SyntaxConstants.VAR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_ARRAY, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CLEAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_ID_CHOICES, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IO_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OBJVAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IF_OTHERWISE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOOPSTATE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_ID_CHOICES,
                                            "Prod_id_choices");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_MULTI, 0, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT_CHOICE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_SUBELEMENT_CHOICE,
                                            "Prod_subelement_choice");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT,
                                            "Prod_varinit");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_INT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_CHAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_STRING, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VARINIT_BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_INT,
                                            "Prod_varinitINT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_DOUBLE,
                                            "Prod_varinitDOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_CHAR,
                                            "Prod_varinitCHAR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_STRING,
                                            "Prod_varinitSTRING");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VARINIT_BOOLEAN,
                                            "Prod_varinitBOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLEAN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_BOOLEAN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INT,
                                            "Prod_INT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS1, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INTCHOICES, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE1, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP1, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INTCHOICES,
                                            "Prod_intchoices");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INTCHOICE1, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INTCHOICE2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INTCHOICE1,
                                            "Prod_intchoice1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INTCHOICE2,
                                            "Prod_intchoice2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLE,
                                            "Prod_DOUBLE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS2, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLECHOICES, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE2, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OP2, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLECHOICES,
                                            "Prod_doublechoices");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLECHOICE1, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_DOUBLECHOICE2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLECHOICE1,
                                            "Prod_doublechoice1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INCDEC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPERATIONS2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOUBLECHOICE2,
                                            "Prod_doublechoice2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CHAR,
                                            "Prod_CHAR");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE3, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STRING,
                                            "Prod_STRING");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE4, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_BOOLEAN,
                                            "Prod_BOOLEAN");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE5, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_TASK_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASK_ID,
                                            "Prod_task_id");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PARAM,
                                            "Prod_param");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_VALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAMS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_PARAMS,
                                            "Prod_params");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SEM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_VALUE,
                                            "Prod_value");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
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
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IO_STATEMENT,
                                            "Prod_io_statement");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OUTPUT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INPUT,
                                            "Prod_input");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.READ, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OUTPUT,
                                            "Prod_output");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SAY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT_STATEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INPUT_STATEMENT,
                                            "Prod_input_statement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT_ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONCAT,
                                            "Prod_concat");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT_VALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONCAT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONCAT_VALUE,
                                            "Prod_concat_value");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT_ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_SUBELEMENT,
                                            "Prod_subelement");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.AT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INPUT_ID,
                                            "Prod_input_id");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MULTI,
                                            "Prod_multi");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEX,
                                            "Prod_index");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
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

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITIONS,
                                            "Prod_conditions");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONSCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDITIONSCHOICE,
                                            "Prod_conditionschoice");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_IDSCHOICE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDS_TAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_MULTICONDS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_MULTICONDS,
                                            "Prod_multiconds");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OPS, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDSCHOICE,
                                            "Prod_idschoice");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOGOP2, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDSCHOICE1, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDSCHOICE1,
                                            "Prod_idschoice1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDSBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BOOLLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_IDSBODY,
                                            "Prod_idsbody");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONDS_TAIL,
                                            "Prod_condsTail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOG_OPS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_REL_OPS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OPS,
                                            "Prod_logOps");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_LOGOP1, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_CONDITIONS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int)SyntaxConstants.PROD_RELOP_TEXT, 1, 1);
            alt.AddProduction((int)SyntaxConstants.PROD_IDSCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_REL_OPS,
                                            "Prod_relOps");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_RELOP_NUM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_NUMVAL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RELOP_NUM,
                                            "Prod_relopNum");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GREAT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RELOP_TEXT,
                                            "Prod_relopText");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ISEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOTEQ, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_NUMVAL,
                                            "Prod_numval");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DOUBLELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_IDSBODY, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTION,
                                            "Prod_option");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OPTION, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_INPUT_ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.START, 1, 1);
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_OPTIONTAILS, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTIONTAILS,
                                            "Prod_optiontails");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTIONTAIL1, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTIONTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_OPTIONTAIL3, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTIONTAIL1,
                                            "Prod_optiontail1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE1, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTIONTAIL2,
                                            "Prod_optiontail2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE2, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPTIONTAIL3,
                                            "Prod_optiontail3");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE3, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_DEFAULT, 0, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE1,
                                            "Prod_state1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE2,
                                            "Prod_state2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CHARLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_STATE3,
                                            "Prod_state3");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.STATE, 1, 1);
            alt.AddToken((int) SyntaxConstants.STRINGLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 0, 1);
            alt.AddToken((int) SyntaxConstants.STOP, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_STATE3, 0, 1);
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
            alt.AddProduction((int) SyntaxConstants.PROD_COND_LOOP, 1, 1);
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
            alt.AddProduction((int) SyntaxConstants.PROD_INCDECVAR, 0, 1);
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
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_COND,
                                            "Prod_cond");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RELOP1, 1, 1);
            alt.AddToken((int) SyntaxConstants.INTLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASKDEF,
                                            "Prod_taskdef");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TASK, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_RETURNTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.END, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PROD_TASKDEF, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURNTYPE,
                                            "Prod_returntype");
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
            alt.AddProduction((int) SyntaxConstants.PROD_TASKBODYTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PROD_TASKBODYTAIL,
                                            "Prod_taskbodytail");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_STATEMENTS, 1, 1);
            alt.AddToken((int) SyntaxConstants.PER, 1, 1);
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
            alt.AddProduction((int) SyntaxConstants.PROD_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PROD_SUBELEMENT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
