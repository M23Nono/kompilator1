using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{

    public enum TokenType
    {
        Kommentariy = 1,           // "//"
        Kommentar1y = 2,           // "#"
        Dvuxstrochniykomm = 3,     // "/*"
        Konecdvuxstrochnogo = 4,   // "*/"
        Perexodnanovuyustroky = 5, // "/n"
        Symbol = 6                 // "oshibka"
    }

    public class Token
    {
        public string Code { get; set; }
        public TokenType Type { get; set; }   // Тип
        public string Value { get; set; }     // Аргумент
        public int Column { get; set; }       // Последователь
        public int Quantity { get; set; }     // Кол-во символов
        public int StartIndex { get; set; }   // Начальное положение
        public int EndIndex { get; set; }     // Конечное положение

        public Token(string code, TokenType type, string value, int column, int quantity, int startIndex, int endIndex)
        {
            Code = code; // Присваиваем переданный код
            Type = type;
            Value = value;
            Column = column;
            Quantity = quantity;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }

    public class Lexer
    {
        protected string input;
        protected int currentPosition;

        public Lexer(string input)
        {
            this.input = input;
            currentPosition = 0;
        }

        public virtual List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            int startIndex = currentPosition;
            bool tokensAdded = false; // Переменная для отслеживания добавления токенов

            while (currentPosition < input.Length)
            {
                char currentChar = input[currentPosition];
                switch (currentChar)
                {
                    case '/':
                        if (currentPosition + 1 < input.Length && input[currentPosition + 1] == '/')
                        {
                            int endOfLine = input.IndexOf('\n', currentPosition + 2);
                            if (endOfLine == -1) endOfLine = input.Length;
                            string comment = input.Substring(currentPosition, endOfLine - currentPosition);
                            tokens.Add(new Token("1", TokenType.Kommentariy, comment, currentPosition, endOfLine - currentPosition, startIndex, endOfLine - 1));
                            currentPosition = endOfLine;
                            startIndex = currentPosition;
                            tokensAdded = true;
                        }
                        else if (currentPosition + 1 < input.Length && input[currentPosition + 1] == '*')
                        {
                            int endCommentIndex = input.IndexOf("*/", currentPosition + 2);
                            if (endCommentIndex == -1)
                                throw new Exception("Unclosed multiline comment");
                            string comment = input.Substring(currentPosition, endCommentIndex - currentPosition + 2);
                            tokens.Add(new Token("3", TokenType.Dvuxstrochniykomm, comment, currentPosition, endCommentIndex - currentPosition + 2, startIndex, endCommentIndex + 1));
                            currentPosition = endCommentIndex + 2;
                            startIndex = currentPosition;
                            tokensAdded = true;
                        }
                        break;
                    case '#':
                        int endOfLineHash = input.IndexOf('\n', currentPosition + 1);
                        if (endOfLineHash == -1) endOfLineHash = input.Length;
                        string hashComment = input.Substring(currentPosition, endOfLineHash - currentPosition);
                        tokens.Add(new Token("2", TokenType.Kommentar1y, hashComment, currentPosition, endOfLineHash - currentPosition, startIndex, endOfLineHash - 1));
                        currentPosition = endOfLineHash;
                        startIndex = currentPosition;
                        tokensAdded = true;
                        break;
                    case '\n':
                        tokens.Add(new Token("5", TokenType.Perexodnanovuyustroky, "\n", currentPosition, 1, startIndex, currentPosition));
                        currentPosition++;
                        startIndex = currentPosition;
                        tokensAdded = true;
                        break;
                    default:
                        int endOfLineDefault = input.IndexOf('\n', currentPosition);
                        if (endOfLineDefault == -1) endOfLineDefault = input.Length;
                        string defaultComment = input.Substring(currentPosition, endOfLineDefault - currentPosition);
                        tokens.Add(new Token("6", TokenType.Symbol, defaultComment, currentPosition, endOfLineDefault - currentPosition, startIndex, endOfLineDefault - 1));
                        currentPosition = endOfLineDefault;
                        startIndex = currentPosition;
                        tokensAdded = true;
                        break;
                }

                // Проверяем, были ли добавлены новые токены
                if (!tokensAdded)
                {
                    break; // Если ни один токен не был добавлен, выходим из цикла
                }

                tokensAdded = false; // Сбрасываем флаг после каждой итерации
            }

            return tokens;
        }
    }
}

