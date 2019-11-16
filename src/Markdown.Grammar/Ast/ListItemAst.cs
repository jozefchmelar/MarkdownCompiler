namespace Markdown.Grammar
{
    public class ListItemAst : BaseAst   {
        public override string StartTag => "<li>";
        public ListContainer Container { get; set; }
    }
    public class ListContainer : BaseAst
    {
        public override string StartTag => "<ul>";
    }
}