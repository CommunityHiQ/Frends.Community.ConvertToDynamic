**[Table of Contents](http://tableofcontent.eu)**
- [Frends.Community.ConvertToDynamic](#frendscommunityconverttodynamic)
  - [Contributing](#contributing)
  - [Documentation](#documentation)
    - [Parameters](#parameters)
    - [Result](#result)
  - [License](#license)


# Frends.Community.ConvertToDynamic
FRENDS Task to convert XmlString, XmlDocument, XDocument or JsonString to Dynamic. Some Frends4 tasks already do this and this might be obsolete.

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
| InputData				| string	| Supported formats JSON and XML | ´<root><field>1</field></root>´ |
| InputType			| XmlString, XmlDocument, XDocument, JsonString 	| Input data type	| ´XmlString´ |
| OptionalRootNameWhenConvertingFromJSON	| string	| Give root name for created object	| ´root´ |

### Result

| Property      | Type     | Description                      |
|---------------|----------|----------------------------------|
| Result        | Dynamic   | Result as dynamic	|

## License

This project is licensed under the MIT License - see the LICENSE file for details
