# Fizzle

## Setup

Fizzle uses EFCore. Setup the initial database and perform migrations with:
```
dotnet ef database update
```

The application will take care of seeding data on first start if the tables are empty.

## Future Improvements

* Allow pre-seed configurable by applicationSettings
* Fizzle on demand


