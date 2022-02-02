# How to configure db connection

---

Create new `appsetting.{MACHINE_NAME}.json` file in `ResourceBasedAuthenticationTest`
with following content:

```json
{
  "ConnectionStrings": {
    "PostgreSQL": "Server=;Port=;Database=enterprise_assistant_rba;User Id=;Password="
  }
}
```

Example connection string:

`Server=127.0.0.1;Port=5432;Database=enterprise_assistant_rba;User Id=postgres;Password=password` 

That was my JSON code block.