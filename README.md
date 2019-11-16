# My very own markdown compiler!

It's my very own and very first compiler

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
  <h1>
    <p>"H1 Heading"</p>
  </h1>
  <h1>
    <u>
      <p>"H1 undescore heading"</p>
    </u>
  </h1>
  <h2>
    <p>"H2 Heading"</p>
  </h2>
  <b>
    <p>"This is bold text"</p>
  </b>
  <p>"and this is regular text"</p>
  <p>"Following three items should be in a list, this is plaintext"</p>
  <ul>
    <li>
      <p>"Plaintext list item"</p>
    </li>
    <li>
      <b>
        <p>"Bold List item"</p>
      </b>
    </li>
    <li>
      <u>
        <b>
          <p>"Underscore bold list item"</p>
        </b>
      </u>
    </li>
    <li>
      <u>
        <p>"Underscore  list item"</p>
      </u>
    </li>
  </ul>
  <h1>
    <p>"This is heading again"</p>
  </h1>
</div>
```