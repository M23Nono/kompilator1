using Laba1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public class PHPCommentParser
    {
        public class Error
        {
            public int Number { get; set; }
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public string Message { get; set; }

            public Error(int number, int startIndex, int endIndex, string message)
            {
                Number = number;
                StartIndex = startIndex;
                EndIndex = endIndex;
                Message = message;
            }
        }

        private string input;

        public PHPCommentParser(string input)
        {
            this.input = input;
        }

        public List<Error> ParseComments()
        {
            List<Error> errors = new List<Error>();

            int errorNumber = 0;
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                if (input[currentIndex] == '/' && currentIndex + 1 < input.Length)
                {
                    if (input[currentIndex + 1] == '/')
                    {
                        // Нашли однострочный комментарий
                        int startIndex = currentIndex;
                        int endIndex = currentIndex;
                        while (endIndex < input.Length && input[endIndex] != '\n')
                        {
                            endIndex++;
                        }
                        string commentText = input.Substring(startIndex, endIndex - startIndex).Trim();
                        if (!IsSingleLineCommentCorrect(commentText))
                        {
                            // Попытка нейтрализации ошибки
                            commentText = TryNeutralizeError(commentText);
                            errors.Add(new Error(++errorNumber, startIndex, endIndex - 1, "Ошибка в однострочном комментарии. Нейтрализовано: " + commentText));
                        }
                    }
                    else if (input[currentIndex + 1] == '*')
                    {
                        // Нашли многострочный комментарий
                        int startIndex = currentIndex;
                        int endIndex = currentIndex;
                        while (endIndex < input.Length - 1 && !(input[endIndex] == '*' && input[endIndex + 1] == '/'))
                        {
                            endIndex++;
                        }
                        if (endIndex < input.Length - 1)
                        {
                            string commentText = input.Substring(startIndex, endIndex - startIndex + 2).Trim();
                            if (!IsMultiLineCommentCorrect(commentText))
                            {
                                // Попытка нейтрализации ошибки
                                commentText = TryNeutralizeError(commentText);
                                errors.Add(new Error(++errorNumber, startIndex, endIndex + 1, "Ошибка в многострочном комментарии. Нейтрализовано: " + commentText));
                            }
                        }
                        else
                        {
                            errors.Add(new Error(++errorNumber, startIndex, endIndex, "Ошибка в многострочном комментарии: нет завершающего символа */"));
                        }
                    }
                    else
                    {
                        // Пропускаем некорректный символ '/'
                        currentIndex++;
                    }
                }
                currentIndex++;
            }

            return errors;
        }

        private bool IsSingleLineCommentCorrect(string comment)
        {
            return comment.StartsWith("//") || comment.StartsWith("#");
        }

        private bool IsMultiLineCommentCorrect(string comment)
        {
            return comment.StartsWith("/*") && comment.EndsWith("*/");
        }

        // Метод для нейтрализации ошибок
        private string TryNeutralizeError(string comment)
        {
            // В данном примере мы просто удаляем первый символ,
            // который является причиной ошибки. 
            // В реальных сценариях это может быть более сложная логика.
            if (comment.Length > 0)
            {
                comment = comment.Substring(1);
            }
            return comment;
        }
    }
}