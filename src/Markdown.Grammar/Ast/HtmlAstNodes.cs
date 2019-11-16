namespace Markdown.Grammar
{
    public class BoldAst : BaseAst
    {
        public override string StartTag => "<b>";
    }
    public class ItalicsAst : BaseAst
    {
        public override string StartTag => "<i>";
    }

    public class UnderscoreAst : BaseAst
    {
        public override string StartTag => "<u>";
    }

    public class H1Ast : BaseAst
    {
        public override string StartTag => "<h1>";
    }
    public class H2Ast : BaseAst
    {
        public override string StartTag => "<h2>";
    }
    public class H3Ast : BaseAst
    {
        public override string StartTag => "<h3>";
    }

    public class RootAst : BaseAst
    {
        public override string StartTag => "<div>";
    }

}