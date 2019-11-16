using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using NUnit.Framework;

namespace Markdown.Grammar.Test
{
    [TestFixture]
    public class Grammar
    {
        private readonly Parser _parser;
        private readonly MarkdownGrammar _grammar;
        private readonly LanguageData _langData;
        private readonly string sampleMarkdownFilePath;

        public Grammar()
        {
            _grammar = new MarkdownGrammar();
            _langData = new LanguageData(_grammar);
            _parser = new Parser(_grammar);
            sampleMarkdownFilePath = @"..\..\..\rawMarkDown.txt";
        }

        [Test]
        public void GrammarIsParsing()
        {
            //arrange
            var toParse = File.ReadAllText(sampleMarkdownFilePath);
            //act
            ParseTree parseTree = _parser.Parse(toParse);
            _grammar.BuildAst(_langData, parseTree);
            Assert.False(parseTree.HasErrors());
            //assert
            Assert.NotNull(parseTree);
        }

        [Test]
        public void VisitorComplingTest()
        {
            //arrange
            var toParse = File.ReadAllText(sampleMarkdownFilePath);
            ParseTree parseTree = _parser.Parse(toParse);
            _grammar.BuildAst(_langData, parseTree);
            var x = parseTree.Root.AstNode as BaseAst;
            var visitor = new HtmlConcreteVisitor(new StringBuilder());
            //act
            x.AcceptVisitor(visitor);
            Console.WriteLine(visitor.CompiledHtml);
            //assert
            Assert.AreEqual(visitor.CompiledHtml,File.ReadAllText( @"..\..\..\compiledMarkDown.txt"));
            Assert.NotNull(parseTree);
        }

    }
}