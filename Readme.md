# AspNetCore-JWT-Sample

Prerequisites:

    1. Docker
    2. Swarm

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