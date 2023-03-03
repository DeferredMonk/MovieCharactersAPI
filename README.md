# MovieCharactersAPI

## Creators
- Kristian Wink
- Marco Angeli

## Purpose
The purpose of this project was for us to master how to create an ASP .NET core API.
During this prosess we mastered Entity framework, AutoMapper, DTOs, Services, Controllers, Migrations and DbContext.

This assignment was provided to us from Noroff as the last assignment of the bootcamp.

## Folder tree
```
│   .gitattributes
│   .gitignore
│   README.md
│
└───MovieCharactersAPI
    │   appsettings.Development.json
    │   appsettings.json
    │   Program.cs
    │
    ├───Controllers				               //Controllers to handle http requests
    │       CharactersController.cs		               //Controls Characters Table
    │       FranchisesController.cs		               //Controls Franchises Table	
    │       MoviesController.cs			               //Controls Movies Table
    │
    ├───Exceptions				               //Custom exceptions
    │       CharacterNotFoundException.cs
    │       FranchiseNotFoundException.cs
    │       MovieNotFoundException.cs
    │
    ├───Migrations				               //Migrations
    │       20230302122800_InitialDb.cs		               //Creates DB with dummy data
    │       20230302122800_InitialDb.Designer.cs
    │       MoviesDbContextModelSnapshot.cs
    │
    ├───Models					               //Data models
    │   │   Character.cs
    │   │   Franchise.cs
    │   │   Movie.cs
    │   │   MoviesDbContext.cs			               //Context of Database
    │   │
    │   └───DTOs				               //Data transfer objects
    │           CharacterDto.cs
    │           FranchiseDto.cs
    │           MovieDto.cs
    │
    ├───Profiles				               //Profiles to map 
    │       CharacterProfile.cs
    │       FranchiseProfile.cs
    │       MovieProfile.cs
    │
    ├───Properties
    │       launchSettings.json
    │
    └───Services				                //Services to handle data
            CharacterService.cs
            FranchiseService.cs
            ICharacterService.cs
            IFranchiseService.cs
            IMovieService.cs
            MovieService.cs
```
