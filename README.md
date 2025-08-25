# history-family-tree (API)

ASP.NET Core (.NET 8) + MySQL (EF Core) minimal API.
Masaüstü Avalonia istemcisi bu API'ye bağlanır.

## Geliştirme

- .NET 8 SDK gerekir
- MySQL 8 (Docker ile host port 3310 örneği)

### Bağlantı dizesi (güvenli)
Üretimde ENV kullanın:
\`\`\`bash
export ConnectionStrings__Default="server=127.0.0.1;port=3310;database=soyagaci;user=soyuser;password=***;TreatTinyAsBoolean=false;CharSet=utf8mb4;"
\`\`\`

### Migration
\`\`\`bash
dotnet ef migrations add Initial
dotnet ef database update
\`\`\`

### Çalıştırma
\`\`\`bash
dotnet run --urls http://0.0.0.0:5010
\`\`\`

Swagger: \`/swagger\`, Sağlık: \`/health\`

## Lisans
MIT (isteğe bağlı güncellenebilir)
