# Criação da estrutura de diretórios do projeto CRUD Produtos

$root = "projeto-crud-produtos"
$api = "$root\api-produtos-dotnet"
$frontend = "$root\frontend-angular-produtos"
$banco = "$root\banco"

# Criar pastas principais
New-Item -Path $root -ItemType Directory
New-Item -Path $api -ItemType Directory
New-Item -Path "$api\Controllers" -ItemType Directory
New-Item -Path "$api\Models" -ItemType Directory
New-Item -Path "$api\Services" -ItemType Directory
New-Item -Path $frontend -ItemType Directory
New-Item -Path "$frontend\src\app\components" -ItemType Directory -Force
New-Item -Path "$frontend\src\app\services" -ItemType Directory -Force
New-Item -Path "$frontend\src\environments" -ItemType Directory -Force
New-Item -Path $banco -ItemType Directory

# Criar arquivos vazios
New-Item -Path "$api\appsettings.json" -ItemType File
New-Item -Path "$api\Program.cs" -ItemType File
New-Item -Path "$api\Startup.cs" -ItemType File
New-Item -Path "$api\README.md" -ItemType File
New-Item -Path "$frontend\README.md" -ItemType File
New-Item -Path "$root\README.md" -ItemType File
New-Item -Path "$banco\script_postgresql.sql" -ItemType File