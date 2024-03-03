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
        kommentariy = 1,   // "//"
        kommentar1y = 2,       // "#"
        dvuxstrochniykomm = 3,    //"/*"
        konecdvuxstrochnogo = 4,    // "*/"
        perexodnanovuyustroky = 5,         // "/n"
        Symbol = 6,          //"oshibka"
    }

    class Token
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

    class Lexer
    {
        private string input;
        private int currentPosition;

        public Lexer(string input)
        {
            this.input = input;
            currentPosition = 0;
        }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            int startIndex = currentPosition;

            while (currentPosition < input.Length)
            {
                char currentChar = input[currentPosition];
                switch (currentChar)
                {
                    case '/':
                        if (currentPosition + 1 < input.Length && input[currentPosition + 1] == '/')
                        {
                            tokens.Add(new Token("1", TokenType.kommentariy, "//", currentPosition, 2, startIndex, currentPosition + 1));
                            currentPosition += 2;
                            startIndex = currentPosition;
                        }
                        else if (currentPosition + 1 < input.Length && input[currentPosition + 1] == '*')
                        {
                            tokens.Add(new Token("3", TokenType.dvuxstrochniykomm, "/*", currentPosition, 2, startIndex, currentPosition + 1));
                            currentPosition += 2;
                            startIndex = currentPosition;
                        }
                        break;
                    case '#':
                        tokens.Add(new Token("2", TokenType.kommentar1y, "#", currentPosition, 1, startIndex, currentPosition));
                        currentPosition++;
                        startIndex = currentPosition;
                        break;
                    case '*':
                        if (currentPosition + 1 < input.Length && input[currentPosition + 1] == '/')
                        {
                            tokens.Add(new Token("4", TokenType.konecdvuxstrochnogo, "*/", currentPosition, 2, startIndex, currentPosition + 1));
                            currentPosition += 2;
                            startIndex = currentPosition;
                        }
                        break;
                    case '\n':
                        tokens.Add(new Token("5", TokenType.perexodnanovuyustroky, "/n", currentPosition, 1, startIndex, currentPosition));
                        currentPosition++;
                        startIndex = currentPosition;
                        break;
                    default:
                        tokens.Add(new Token("6", TokenType.Symbol, "o", currentPosition, 1, startIndex, currentPosition));
                        currentPosition++;
                        startIndex = currentPosition;
                        break;
                }
            }

            return tokens;
        }
    }
}

