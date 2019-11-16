using System.Text;
using System.Xml.Linq;
using Irony.Interpreter.Ast;

namespace Markdown.Grammar
{
    public class HtmlConcreteVisitor : IAstWriteableVisitor
    {
        private readonly StringBuilder StringBuilder;

        public HtmlConcreteVisitor(StringBuilder stringBuilder)
        {
            StringBuilder = stringBuilder;
        }

        public string CompiledHtml => XDocument.Parse(StringBuilder.ToString()).ToString();

        public void BeginVisit(IVisitableNode node)
        {
            var baseAst = (node as BaseAst);
            Write(baseAst.StartTag);
        }

        public void EndVisit(IVisitableNode node)
        {
            var baseAst = (node as BaseAst);
            Write(baseAst.EndTag);
        }

        public void Write(string code)
        {
            StringBuilder.Append(code);
        }

        public void WriteLine(string code)
        {
            StringBuilder.AppendLine(code);
        }
    }
}