using Irony.Parsing;

namespace Markdown.Grammar
{
    [Language("MyMarkdownNetStandart", "1.0", "Custom Markdown Language")]
    public class MarkdownGrammar : Irony.Parsing.Grammar
    {
        private readonly NonTerminal Bold = new NonTerminalMd(nameof(Bold), typeof(BoldAst));
        private readonly NonTerminal Italics = new NonTerminalMd(nameof(Italics), typeof(ItalicsAst));
        private readonly NonTerminal Underscore = new NonTerminalMd(nameof(Underscore), typeof(UnderscoreAst));
        private readonly NonTerminal StyledText = new NonTerminalMd(nameof(StyledText));
        private readonly NonTerminal Text = new NonTerminalMd(nameof(Text));

        private readonly NonTerminal H1 = new NonTerminalMd(nameof(H1), typeof(H1Ast));
        private readonly NonTerminal H2 = new NonTerminalMd(nameof(H2), typeof(H2Ast));
        private readonly NonTerminal H3 = new NonTerminalMd(nameof(H3), typeof(H3Ast));

        private readonly NonTerminal ListItem = new NonTerminalMd(nameof(ListItem), typeof(ListItemAst));

        private readonly NonTerminal MarkdownElement = new NonTerminalMd(nameof(MarkdownElement));
        private readonly NonTerminal MarkdownContent = new NonTerminalMd(nameof(MarkdownContent), typeof(RootAst));

        private readonly Terminal PlainText = new StringLiteral(nameof(PlainText), "\"", StringOptions.AllowsLineBreak, typeof(PlainTextAst));

        public MarkdownGrammar()
        {
            Bold.Rule = "*" + Text + "*";
            Italics.Rule = "/" + Text + "/";
            Underscore.Rule = "_" + Text + "_";
            StyledText.Rule = Bold | Italics | Underscore;
            Text.Rule = PlainText | StyledText;

            H1.Rule = "#" + Text;
            H2.Rule = "##" + Text;
            H3.Rule = "###" + Text;

            ListItem.Rule = "-" + Text;

            MarkdownElement.Rule = Text | H1 | H2 | H3 | ListItem;
            MarkdownContent.Rule = MakeStarRule(MarkdownContent, MarkdownElement);
            Root = MarkdownContent;

            MarkTransient(StyledText, Text, MarkdownElement);

            LanguageFlags = LanguageFlags.CreateAst;
        }
    }
}