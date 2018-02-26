# AspNetCore-JWT-Sample

Prerequisites:

* Docker
* Swarm

## Setup

Create secret:

```bash
docker secret create jwt-config jwt-config.json
```

To build all container images:

```bash
docker-compose build
```

Deploy the stack:

```bash
docker stack deploy -c docker-compose.yml token
```

## Usage

Call

```
POST http://localhost:5000/api/token
{
    "username" : "mickey",
    "password" : "mouse"
}
```

To get the token:

```
{
    "token": "<JWT-TOKEN>"
}
```

Add the token as ```Bearer Authorization header```

```
Authorization: Bearer <JWT-TOKEN>
```

To get:

```
GET http://localhost:5001/api/cars/
```

Play around