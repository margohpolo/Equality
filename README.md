## Equality

Equality checks with unit tests for Entities and ValueObjects.

An assumption was made here that Entities will behave similarly to ValueObjects, but will be persisted in DBs (as tables), and hence would require Ids. Their behaviours, however, would be similar in terms of GetHashCode() and Equals() implementations.

#### ValueObjects
- Money (single underlying value)
- DateTimeRange (for Period overlap checks & duration calculations)
- PhoneNumber (includes a nullable field)
- Address (Multiple fields, including nullables)

#### Entities
- Person


<br />

### GetProperties()

Reflection was used to iteratively get the property values, for the equality checks. (see <a href="Equality.Domain/Primitives/ValueObject.cs" target="_blank">here</a>.)




<br />
<br />
<br />
Credits go to <a href="https://www.youtube.com/@MilanJovanovicTech" target="_blank">Milan</a> for his tutorial on ValueObjects, as well as for the cool name `GetAtomicValues()`.