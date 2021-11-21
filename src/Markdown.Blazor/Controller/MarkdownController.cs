using Irony.Parsing;
using Markdown.Grammar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Blazor.Controller
{
    public class MarkdownController
    {
        private readonly MarkdownGrammar MarkdownGrammar;
        private readonly LanguageData LanguageData;
        private readonly Parser Parser;

        public MarkdownController()
        {
            MarkdownGrammar = new MarkdownGrammar();
            LanguageData = new LanguageData(MarkdownGrammar);
            Parser = new Parser(LanguageData);
        }

        public string ConvertToHtml(string toParse)
        {
            ParseTree parseTree = Parser.Parse(toParse);
            if (parseTree.HasErrors())
                return $"{Parser.Context.Status} before processing \"{Parser.Context.CurrentToken}\" at {Parser.Context.Source}"; MarkdownGrammar.BuildAst(LanguageData, parseTree);
            var x = parseTree.Root.AstNode as BaseAst;
            var visitor = new HtmlConcreteVisitor(new StringBuilder());
            x.AcceptVisitor(visitor);
            return visitor.CompiledHtml;
        }
    }
}
