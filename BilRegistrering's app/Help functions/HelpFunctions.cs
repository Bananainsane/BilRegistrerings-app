using System.Net.Mail;

namespace BilRegistrering_s_app.Help_functions
{
    internal class HelpFunctions
    {
        // This method checks whether a string contains only digits or not
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public static bool IsLetterAndSpacesOnly(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsLetterOrDigit(c) && c != ' ')
                    return false;
            }
            return true;
        }

        // This method checks whether a string contains only letters or not
        public static bool IsLettersonly(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        // This method checks whether a string contains only letters or digits or not
        public static bool IsAllLettersOrDigits(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        // This method checks whether a string is a valid email address or not
        public static bool IsValidEmail(string str)
        {
            try
            {
                MailAddress addr = new MailAddress(str);
                return addr.Address == str;
            }
            catch
            {
                return false;
            }
        }
        // This method clears the console from the current cursor position to the end of the current line
        public static void ClearToEndOfCurrentLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft));
            Console.SetCursorPosition(0, currentLineCursor);
        }




        // This method clears the console from the current cursor position to the end of the next line
        public static void ClearNextLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft));
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }
}
