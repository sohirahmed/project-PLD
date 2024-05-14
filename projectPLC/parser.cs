
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF             =  0, // (EOF)
        SYMBOL_ERROR           =  1, // (Error)
        SYMBOL_WHITESPACE      =  2, // Whitespace
        SYMBOL_MINUS           =  3, // '-'
        SYMBOL_MINUSMINUS      =  4, // '--'
        SYMBOL_PERCENT         =  5, // '%'
        SYMBOL_LPAREN          =  6, // '('
        SYMBOL_RPAREN          =  7, // ')'
        SYMBOL_TIMES           =  8, // '*'
        SYMBOL_DIV             =  9, // '/'
        SYMBOL_COLON           = 10, // ':'
        SYMBOL_SEMI            = 11, // ';'
        SYMBOL_LBRACE          = 12, // '{'
        SYMBOL_RBRACE          = 13, // '}'
        SYMBOL_PLUS            = 14, // '+'
        SYMBOL_PLUSPLUS        = 15, // '++'
        SYMBOL_LT              = 16, // '<'
        SYMBOL_LTEQ            = 17, // '<='
        SYMBOL_LTGT            = 18, // '<>'
        SYMBOL_EQ              = 19, // '='
        SYMBOL_EQEQ            = 20, // '=='
        SYMBOL_GT              = 21, // '>'
        SYMBOL_GTEQ            = 22, // '>='
        SYMBOL_BREAK           = 23, // break
        SYMBOL_CASE            = 24, // case
        SYMBOL_DEFAULT         = 25, // default
        SYMBOL_DIGIT           = 26, // Digit
        SYMBOL_DO              = 27, // do
        SYMBOL_ELSE            = 28, // else
        SYMBOL_FOR             = 29, // For
        SYMBOL_ID              = 30, // Id
        SYMBOL_IF              = 31, // if
        SYMBOL_INTEGER         = 32, // Integer
        SYMBOL_LET             = 33, // let
        SYMBOL_STRINGLITERAL   = 34, // StringLiteral
        SYMBOL_SWITCH          = 35, // switch
        SYMBOL_VAR             = 36, // var
        SYMBOL_WHILE           = 37, // while
        SYMBOL_ADD_EXPR        = 38, // <add_expr>
        SYMBOL_ASSIGN          = 39, // <assign>
        SYMBOL_CASELIST        = 40, // <caselist>
        SYMBOL_CONCEPT         = 41, // <concept>
        SYMBOL_DEFAULT2        = 42, // <default>
        SYMBOL_DOWHILE_LOOP    = 43, // <dowhile_loop>
        SYMBOL_EXPR            = 44, // <expr>
        SYMBOL_FOR_STMT        = 45, // <for_stmt>
        SYMBOL_IF_STMT         = 46, // <if_stmt>
        SYMBOL_INIT            = 47, // <init>
        SYMBOL_MUL_EXPR        = 48, // <mul_expr>
        SYMBOL_NEGATIVE_EXPR   = 49, // <negative_expr>
        SYMBOL_PROGRAM         = 50, // <program>
        SYMBOL_STEP            = 51, // <step>
        SYMBOL_STMT_LIST       = 52, // <stmt_list>
        SYMBOL_SWITCH_STMT     = 53, // <switch_stmt>
        SYMBOL_TYPE            = 54, // <type>
        SYMBOL_VALUE           = 55, // <Value>
        SYMBOL_VARIABLE_DECLAR = 56, // <variable_declar>
        SYMBOL_WHILE_LOOP      = 57  // <while_loop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                   =  0, // <program> ::= <stmt_list>
        RULE_STMT_LIST                                                 =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                                =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                                   =  3, // <concept> ::= <variable_declar>
        RULE_CONCEPT2                                                  =  4, // <concept> ::= <assign>
        RULE_CONCEPT3                                                  =  5, // <concept> ::= <if_stmt>
        RULE_CONCEPT4                                                  =  6, // <concept> ::= <switch_stmt>
        RULE_CONCEPT5                                                  =  7, // <concept> ::= <for_stmt>
        RULE_CONCEPT6                                                  =  8, // <concept> ::= <while_loop>
        RULE_CONCEPT7                                                  =  9, // <concept> ::= <dowhile_loop>
        RULE_VARIABLE_DECLAR_ID_EQ                                     = 10, // <variable_declar> ::= <type> Id '=' <expr>
        RULE_TYPE_VAR                                                  = 11, // <type> ::= var
        RULE_TYPE_LET                                                  = 12, // <type> ::= let
        RULE_ASSIGN_ID_EQ                                              = 13, // <assign> ::= Id '=' <expr>
        RULE_IF_STMT_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 14, // <if_stmt> ::= if '(' <expr> ')' '{' <stmt_list> '}'
        RULE_IF_STMT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 15, // <if_stmt> ::= if '(' <expr> ')' '{' <stmt_list> '}' else '{' <stmt_list> '}'
        RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE            = 16, // <switch_stmt> ::= switch '(' <expr> ')' '{' <caselist> <default> '}'
        RULE_CASELIST                                                  = 17, // <caselist> ::= 
        RULE_CASELIST_CASE_COLON_BREAK                                 = 18, // <caselist> ::= <caselist> case <expr> ':' <stmt_list> break
        RULE_CASELIST_CASE_COLON_BREAK2                                = 19, // <caselist> ::= case <expr> ':' <stmt_list> break
        RULE_DEFAULT_DEFAULT_COLON                                     = 20, // <default> ::= default ':' <stmt_list>
        RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE        = 21, // <for_stmt> ::= For '(' <init> ';' <expr> ';' <step> ')' '{' <stmt_list> '}'
        RULE_INIT_ID_EQ                                                = 22, // <init> ::= <type> Id '=' <expr>
        RULE_STEP_MINUSMINUS_ID                                        = 23, // <step> ::= '--' Id
        RULE_STEP_ID_MINUSMINUS                                        = 24, // <step> ::= Id '--'
        RULE_STEP_PLUSPLUS_ID                                          = 25, // <step> ::= '++' Id
        RULE_STEP_ID_PLUSPLUS                                          = 26, // <step> ::= Id '++'
        RULE_WHILE_LOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE              = 27, // <while_loop> ::= while '(' <expr> ')' '{' <stmt_list> '}'
        RULE_DOWHILE_LOOP_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN         = 28, // <dowhile_loop> ::= do '{' <stmt_list> '}' while '(' <expr> ')'
        RULE_EXPR_GT                                                   = 29, // <expr> ::= <expr> '>' <add_expr>
        RULE_EXPR_LT                                                   = 30, // <expr> ::= <expr> '<' <add_expr>
        RULE_EXPR_LTEQ                                                 = 31, // <expr> ::= <expr> '<=' <add_expr>
        RULE_EXPR_GTEQ                                                 = 32, // <expr> ::= <expr> '>=' <add_expr>
        RULE_EXPR_EQEQ                                                 = 33, // <expr> ::= <expr> '==' <add_expr>
        RULE_EXPR_LTGT                                                 = 34, // <expr> ::= <expr> '<>' <add_expr>
        RULE_EXPR                                                      = 35, // <expr> ::= <add_expr>
        RULE_ADD_EXPR_PLUS                                             = 36, // <add_expr> ::= <add_expr> '+' <mul_expr>
        RULE_ADD_EXPR_MINUS                                            = 37, // <add_expr> ::= <add_expr> '-' <mul_expr>
        RULE_ADD_EXPR                                                  = 38, // <add_expr> ::= <mul_expr>
        RULE_MUL_EXPR_TIMES                                            = 39, // <mul_expr> ::= <mul_expr> '*' <negative_expr>
        RULE_MUL_EXPR_DIV                                              = 40, // <mul_expr> ::= <mul_expr> '/' <negative_expr>
        RULE_MUL_EXPR_PERCENT                                          = 41, // <mul_expr> ::= <mul_expr> '%' <negative_expr>
        RULE_MUL_EXPR                                                  = 42, // <mul_expr> ::= <negative_expr>
        RULE_NEGATIVE_EXPR_MINUS                                       = 43, // <negative_expr> ::= '-' <Value>
        RULE_NEGATIVE_EXPR                                             = 44, // <negative_expr> ::= <Value>
        RULE_VALUE_ID                                                  = 45, // <Value> ::= Id
        RULE_VALUE_INTEGER                                             = 46, // <Value> ::= Integer
        RULE_VALUE_STRINGLITERAL                                       = 47, // <Value> ::= StringLiteral
        RULE_VALUE_LPAREN_RPAREN                                       = 48  // <Value> ::= '(' <expr> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LET :
                //let
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADD_EXPR :
                //<add_expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASELIST :
                //<caselist>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2 :
                //<default>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWHILE_LOOP :
                //<dowhile_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INIT :
                //<init>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MUL_EXPR :
                //<mul_expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATIVE_EXPR :
                //<negative_expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT :
                //<switch_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_DECLAR :
                //<variable_declar>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_LOOP :
                //<while_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <variable_declar>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <switch_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <while_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <dowhile_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLAR_ID_EQ :
                //<variable_declar> ::= <type> Id '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_VAR :
                //<type> ::= var
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_LET :
                //<type> ::= let
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_ID_EQ :
                //<assign> ::= Id '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<if_stmt> ::= if '(' <expr> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<if_stmt> ::= if '(' <expr> ')' '{' <stmt_list> '}' else '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch_stmt> ::= switch '(' <expr> ')' '{' <caselist> <default> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<caselist> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON_BREAK :
                //<caselist> ::= <caselist> case <expr> ':' <stmt_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON_BREAK2 :
                //<caselist> ::= case <expr> ':' <stmt_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT_COLON :
                //<default> ::= default ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stmt> ::= For '(' <init> ';' <expr> ';' <step> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INIT_ID_EQ :
                //<init> ::= <type> Id '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS_ID :
                //<step> ::= '--' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_MINUSMINUS :
                //<step> ::= Id '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS_ID :
                //<step> ::= '++' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_PLUSPLUS :
                //<step> ::= Id '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_LOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<while_loop> ::= while '(' <expr> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILE_LOOP_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<dowhile_loop> ::= do '{' <stmt_list> '}' while '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_GT :
                //<expr> ::= <expr> '>' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LT :
                //<expr> ::= <expr> '<' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LTEQ :
                //<expr> ::= <expr> '<=' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_GTEQ :
                //<expr> ::= <expr> '>=' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_EQEQ :
                //<expr> ::= <expr> '==' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LTGT :
                //<expr> ::= <expr> '<>' <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <add_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADD_EXPR_PLUS :
                //<add_expr> ::= <add_expr> '+' <mul_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADD_EXPR_MINUS :
                //<add_expr> ::= <add_expr> '-' <mul_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADD_EXPR :
                //<add_expr> ::= <mul_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MUL_EXPR_TIMES :
                //<mul_expr> ::= <mul_expr> '*' <negative_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MUL_EXPR_DIV :
                //<mul_expr> ::= <mul_expr> '/' <negative_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MUL_EXPR_PERCENT :
                //<mul_expr> ::= <mul_expr> '%' <negative_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MUL_EXPR :
                //<mul_expr> ::= <negative_expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATIVE_EXPR_MINUS :
                //<negative_expr> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATIVE_EXPR :
                //<negative_expr> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_ID :
                //<Value> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
