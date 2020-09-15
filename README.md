# Fizzle

## Setup

Fizzle uses EFCore. Setup the initial database and perform migrations with:
```
dotnet ef database update
```

The application will take care of seeding data on first start if the tables are empty.

## Features

* Preset numbers populated in the database that have been FizzBuzzed
* Auto Fizzle! Use the transform endpoint to FizzBuzz any number.


## Deployment

* Use the Devops Pipeline
* Use `dotnet` cli to produce a publishable package and manually deploy

```
dotnet publish Fizzle.sln -c Release --force -o Publish/
```

This will produce the app ready for release.