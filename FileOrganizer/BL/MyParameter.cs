using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace FileOrganizer.BL
{

    public class MyParameter
    {
        /// <summary>
        /// This is only called by dOOdads architecture.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="param"></param>
        public MyParameter(string column, SQLiteParameter param)
        {
            this._column = column;
            this._param = param;
            this._operator = MyOperand.Equal;
        }

        /// <summary>
        /// Used to determine if the WhereParameters has a value
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
        }

        /// <summary>
        /// The column in the BusinessEntity that this WhereParameter is going to query against. 
        /// </summary>
        public string Column
        {
            get
            {
                return _column;
            }
        }

        /// <summary>
        /// The actual database Parameter 
        /// </summary>
        public SQLiteParameter Param
        {
            get
            {
                return _param;
            }
        }

        /// <summary>
        /// The value that will be placed into the Parameter
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// The type of comparison desired
        /// </summary>
        public MyOperand Operator
        {
            get
            {
                return _operator;
            }

            set
            {
                _operator = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// The type of conjuction to use, "AND" or "OR"
        /// </summary>
        public MyConj Conjuction
        {
            get
            {
                return _conjuction;
            }

            set
            {
                _conjuction = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Used when use the Operand.Between comparison
        /// </summary>
        public object BetweenBeginValue
        {
            get
            {
                return _betweenBegin;
            }

            set
            {
                _betweenBegin = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Used when use the Operand.Between comparison
        /// </summary>
        public object BetweenEndValue
        {
            get
            {
                return _betweenEnd;
            }

            set
            {
                _betweenEnd = value;
                _isDirty = true;
            }
        }

        private MyOperand _operator;
        private MyConj _conjuction = MyConj.UseDefault;
        private object _value = null;
        private string _column;
        private SQLiteParameter _param;
        private bool _isDirty = false;

        private object _betweenBegin = null;
        private object _betweenEnd = null;

        public string SqlFunction = null;


    }

}
