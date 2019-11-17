using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Markdown.Grammar
{
    public class PlainTextAst : BaseAst  {
        public override string StartTag => "<p>";
        public string Text { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            this.AsString = treeNode.Token.Text;
            this.Text = AsString.Replace("\"","");
        }

        public override void AcceptVisitor(IAstVisitor visitor)
        {
            if(Parent is RootAst)
            visitor.BeginVisit(this);
            if(visitor is IAstWriteableVisitor writeableVisitor)
                writeableVisitor.Write(Text);
            if (Parent is RootAst)
                visitor.EndVisit(this);
        }
    }
}