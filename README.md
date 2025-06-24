# dotnet-backend-with-security-issues

The .NET backend contains various security vulnerabilities that need to be found. The project can be used for training purposes to test yourself or others.
The application is a REST-API application that communicates with a postgres database.

### Requirement:
- Docker or Kubernetes

#### Local installation with Docker:
1) Check out project
2) Enter password for Postgres DB in the .env file
3) Open a terminal in the root directory of the project and execute ```docker compose up``` there
4) API tests using Swagger Url: \{domain\}/swagger/index.html 
   - Example: http://localhost:8080/swagger/index.html
5) Access via corresponding endpoints (see below)

#### Local installation in Kubernetes Cluster:
-> comming soon


### Endpoints:

#### SaveEntry
**Path:** /Api/IssuesForum/SaveEntry<br>
**Method:** POST<br>
**Description:** Saves a new entry in the forum.<br>
**Payload:**
```json
{
  "title": "", # Forum Title 
  "content": "" # Forum Content
}

```

#### GetAllEntries
**Path:** /Api/IssuesForum/GetAllEntries<br>
**Method:** Get<br>
**Description:** Returns all entries from the forum DB.<br>
**Response:**<br>
```json
[
  {
    "id": 10, # Entry ID
    "title": "Second entry", # Forum Title
    "content": "I am the second entry in our forum" # Forum Content
  },
  {
  .
  .
  .
  }
]

```

#### Reset 
**Path:** /Api/IssuesForum/SaveEntry<br>
**Method:** POST<br>
**Description:** Remove all entries from forum DB and seed default data<br>
**Payload:**
```json
{
  "title": "", # Forum Title 
  "content": "" # Forum Content
}

```

