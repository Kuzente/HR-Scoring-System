# HR-Scoring-System
A system where employees can be scored for human resources

1. First, I designed the necessary database architecture for the system.
2. Then, I created my N-layered architecture and started building my entities.
3. In my DataAccess layer, I created my repositories, established my database connection, and wrote the necessary queries.
4. I connected my Business layer with DataAccess and created the necessary abstract and concrete classes.
5. In the Presentation layer, I coded the lifetimes of the repositories required for DI as an extension method and established their connections.
6. To avoid exposing entities directly to the user, I created a DTO layer and used AutoMapper library to map my entities.
