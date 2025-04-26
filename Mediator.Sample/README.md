##  Sample requests and pipelines

### Pipeline A
- ExceptionHandlingMiddleware
- MiddlewareA


### Pipeline B
- ExceptionHandlingMiddleware
- ValidationMiddleware
- SpecialMiddleware (<code>where TRequest : ISpecialRequest</code>)
- MiddlewareB

<br>

| Request | Pipeline | Middlewares |
|---------|----------|-------------|
| RequestA | Pipeline A | • ExceptionHandlingMiddleware<br>• MiddlewareA|
| SpecialRequestA | Pipeline A | • ExceptionHandlingMiddleware<br>• MiddlewareA|
| RequestB | Pipeline B | • ExceptionHandlingMiddleware<br>• ValidationMiddleware<br>• MiddlewareB|
| SpecialRequestB | Pipeline B | • ExceptionHandlingMiddleware<br>• ValidationMiddleware<br>• SpecialMiddleware<br>• MiddlewareB|
