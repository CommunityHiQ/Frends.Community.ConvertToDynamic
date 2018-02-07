**[Table of Contents](http://tableofcontent.eu)**
- [Frends.Community.ConvertToDynamic](#frendscommunityconverttodynamic)
  - [Contributing](#contributing)
  - [Documentation](#documentation)
    - [Parameters](#parameters)
    - [Result](#result)
  - [License](#license)


# Frends.Community.ConvertToDynamic
FRENDS Task to convert XmlString, XmlDocument, XDocument or JsonString to Dynamic. Converting data to dynamic enables dot notation in Frends. For example, after this tas it is possible to acces value associated with name 'Addres' using syntax: #result[ConvertToDynamic].Address. Usually Frends task have ability to convert their result to JToken that also enables the dot notation, if they do it is advisable to use JToken not this task. 

## Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

## Documentation

### Params

| Property				|  Type   | Description								| Example                     |
|-----------------------|---------|-----------------------------------------|-----------------------------|
| InputData				| string	| Supported formats JSON and XML | `<root><field>1</field></root>` |
| InputType			| XmlString, XmlDocument, XDocument, JsonString 	| Input data type	| `XmlString`|
| OptionalRootNameWhenConvertingFromJSON	| string	| Give root name for created object	| `root` |

### Result

| Property      | Type     | Description                      |
|---------------|----------|----------------------------------|
| Result        | Dynamic   | Result as dynamic	|

## License

This project is licensed under the MIT License - see the LICENSE file for details
