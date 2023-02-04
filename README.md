# [API Assignment - Tests](https://github.com/thulin82/api-assignment-tests)

API Tests for the Todo Application

## How to use (locally)

###  Build
```bash
docker build -t todoapitests .
```

### Run
```bash
docker run -dit --name todoapitests todoapitests
```

## How to use (jenkins/local registry)

###  Build
```bash
docker build -t localhost:5000/todoapitests .
```

### Push to local registry
```bash
docker push localhost:5000/todoapitests
```

© Markus Thulin 2019-