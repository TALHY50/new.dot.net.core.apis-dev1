sudo rsync -avzh --progress "dev/" "/var/www/html/new.dot.net.core.apis"

cd /var/www/html/new.dot.net.core.apis/IMT/src/IMT.Web && /usr/bin/dotnet build IMT.Web.csproj

sudo systemctl restart IMTWeb.service
