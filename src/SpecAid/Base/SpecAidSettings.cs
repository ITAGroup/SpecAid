using System.Configuration;

namespace SpecAid.Base
{
    public static class SpecAidSettings
    {
        private static bool? _useHashTag;

        public static bool UseHashTag
        {
            get
            {
                if (_useHashTag == null)
                {
                    _useHashTag = GetUseHashTag();
                }

                return _useHashTag.Value;
            }
            set { _useHashTag = value; }
        }

        private static bool GetUseHashTag()
        {
            var useHashTag = ConfigurationManager.AppSettings["SpecAidUseHashTag"];

            if (useHashTag == null)
                return false;

            if (bool.Parse(useHashTag) == false)
                return false;

            return true;
        }


        private static bool? _assertWhenUnknownColumn;
        
        /// <summary>
        /// AssertWhenUnknownColumn is the reverse of use the unknown action.
        /// When AssertWhenUnknownColumn is not used... 
        ///   Assume Specflow.Assist behavior and Use UnknownColumn
        /// </summary>
        public static bool AssertWhenUnknownColumn
        {
            get
            {
                if (_assertWhenUnknownColumn == null)
                {
                    _assertWhenUnknownColumn = GetAssertWhenUnknownColumn();
                }

                return _assertWhenUnknownColumn.Value;
            }
            set { _assertWhenUnknownColumn = value; }
        }

        private static bool GetAssertWhenUnknownColumn()
        {
            var crashWhenUnknown = ConfigurationManager.AppSettings["SpecAidAssertWhenUnknownColumn"];

            if (crashWhenUnknown == null)
                return false;

            if (bool.Parse(crashWhenUnknown) == false)
                return false;

            return true;
        }
    }
}
