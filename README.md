# TraineeTrackerTestFramework



# API  - CRUD Functionality

## Trainee

- Read Own Tracker
- Read Own Profile
- Update Tracker
- Update Own Profile

## Trainer

- Update Trainee Profile Comments
- Read Trainee
- Read Own Profile
- Update Own Profile
- Create Trainee for Own Course
- Delete Trainee from Own Course

## Admin

- Everything

## Postman

### To Add:

```csharp
POST <base_url>/api/<Profile>/
```

plus JSON data

### To Update:

```csharp
PUT <base_url>/api/<Profile>/<id>
```

plus JSON data

### To Retrieve:

```csharp
GET <base_url>/api/<Profile>/<id>
```

### To Delete:

```csharp
DELETE <base_url>/api/<Profile>/<id>
```

where <base_url> can be https://localhost:7234 endpoint

<Profile> is one of "Trainee", "Trainer"



