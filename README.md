# Frends.Community.ConvertToDynamic

[![Actions Status](https://github.com/CommunityHiQ/Frends.Community.ConvertToDynamic/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.ConvertToDynamic/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.ConvertToDynamic) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [ConvertToDynamic](#ConvertToDynamic)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.ConvertToDynamic

# Tasks

## ConvertToDynamic

FRENDS Task to convert XmlString, XmlDocument, XDocument or JsonString to Dynamic. Converting data to dynamic enables dot notation in Frends. For example, after this tas it is possible to acces value associated with name 'Addres' using syntax: #result[ConvertToDynamic].Address. Usually Frends task have ability to convert their result to JToken that also enables the dot notation, if they do it is advisable to use JToken not this task. 

### Params

| Property				|  Type   | Description								| Example                     |
|-----------------------|---------|-----------------------------------------|-----------------------------|
| InputData				| string	| Supported formats JSON and XML | `<root><field>1</field></root>` |
| InputType			| XmlString, XmlDocument, XDocument, JsonString 	| Input data type	| `XmlString`|
| OptionalRootNameWhenConvertingFromJSON	| string	| Give root name for created object	| `root` |

### Returns

| Property      | Type     | Description                      |
|---------------|----------|----------------------------------|
| Result        | Dynamic   | Result as dynamic	|


# Building

Clone a copy of the repository

`git clone https://github.com/CommunityHiQ/Frends.Community.ConvertToDynamic.git`

Rebuild the project

`dotnet build`

Run tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repository on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 1.0.1   | Converted to support .Net Standard 2.0 and .Net Framework 4.7.1 |
