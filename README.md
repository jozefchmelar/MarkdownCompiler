# My very own markdown compiler!

It's my very own and very first compiler. Also my first [medium article](https://medium.com/@Jozefchmelar/how-i-built-a-simple-compiler-markdown-to-html-4da63dc79a94?sk=237f0a7bdf9314f73adf8818f79465fa)

It takes my very poor copy of markdown which supports
```
# header
## header2
### header3
*bold*  _underscore /italics/
- list
- list
- list
```
Basicly what it does it that it takes my markdown, parses it and spits out HTML.
It kinda sucks, but it works.


## Input
Soo from my cool markdown 
```
#"H1 Heading"
#_"H1 undescore heading"_
##"H2 Heading"
*"This is bold text"* "and this is regular text"
"Following three items should be in a list, this is plaintext"
- "Plaintext list item"
- *"Bold List item"*
- _*"Underscore bold list item"*_
- _"Underscore  list item"_
#"This is heading again"
```

## Output
You get this result

```html
<div>
  <h1>H1 Heading</h1>
  <h1>
    <u>H1 undescore heading</u>
  </h1>
  <h2>H2 Heading</h2>
  <b>This is bold text</b>
  <p>and this is regular text</p>
  <p>Following three items should be in a list, this is plaintext</p>
  <ul>
    <li>Plaintext list item</li>
    <li>
      <b>Bold List item</b>
    </li>
    <li>
      <u>
        <b>Underscore bold list item</b>
      </u>
    </li>
    <li>
      <u>Underscore  list item</u>
    </li>
  </ul>
  <h1>This is heading again</h1>
</div>
```
