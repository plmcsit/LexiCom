/*
 * ParserLogException.cs
 */

using System;
using System.Collections;
using System.Text;

namespace Core.Library {

    /**
     * A parser log exception. This class contains a list of all the
     * parse errors encountered while parsing.
     *

     * 
     * @since    1.1
     */
    public class ParserLogException : Exception {

        /**
         * The list of errors found.
         */
        private ArrayList errors = new ArrayList();

        /**
         * Creates a new empty parser log exception.
         */
        public ParserLogException() {
        }

        /**
         * The message property (read-only). This property contains
         * the detailed exception error message.
         */
        public override string Message {
            get{
                StringBuilder  buffer = new StringBuilder();

                for (int i = 0; i < Count; i++) {
                    if (i > 0) {
                        buffer.Append("\n");
                    }
                    buffer.Append(this[i].Message);
                }
                return buffer.ToString();
            }
        }

        /**
         * The error count property (read-only).
         *
         * 
         */
        public int Count {
            get {
                return errors.Count;
            }
        }

        /**
         * Returns the number of errors in this log.
         *
         * @return the number of errors in this log
         *
         * @see #Count
         *
         * @deprecated Use the Count property instead.
         */
        public int GetErrorCount() {
            return Count;
        }

        /**
         * The error index (read-only). This index contains all the
         * errors in this error log.
         *
         * @param index          the error index, 0 <= index < Count
         *
         * @return the parse error requested
         *
         * 
         */
        public ParseException this[int index] {
            get {
                return (ParseException) errors[index];
            }
        }

        /**
         * Returns a specific error from the log.
         *
         * @param index          the error index, 0 <= index < count
         *
         * @return the parse error requested
         *
         * @deprecated Use the class indexer instead.
         */
        public ParseException GetError(int index) {
            return this[index];
        }

        /**
         * Adds a parse error to the log.
         *
         * @param e              the parse error to add
         */
        public void AddError(ParseException e) {
            errors.Add(e);
        }

        /**
         * Returns the detailed error message. This message will contain
         * the error messages from all errors in this log, separated by
         * a newline.
         *
         * @return the detailed error message
         *
         * @see #Message
         *
         * @deprecated Use the Message property instead.
         */
        public string GetMessage() {
            return Message;
        }
    }
}
