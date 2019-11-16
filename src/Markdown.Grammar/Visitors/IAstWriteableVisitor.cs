using Irony.Interpreter.Ast;

namespace Markdown.Grammar
{
    interface IAstWriteableVisitor : IAstVisitor
    {
        void Write(string code);
        void WriteLine(string code);
    }
}