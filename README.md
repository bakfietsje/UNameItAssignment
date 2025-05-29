# 📦 UNameItAssignment

A project developed as part of the UNameIt technical assessment.

<details>
  <summary>📚 Table of Contents</summary>

- [About the Project](#about-the-project)  
- [Getting Started](#getting-started)  
  - [Requirements](#requirements)  
  - [Installation](#installation)  
- [Usage](#usage)  

</details>

---

## 📝 About the Project

This repository contains the solution for the UNameItAssignment coding assessment.  
It consists of a self-hosted ASP .NET Core Web API that exposes an endpoint to count words in an input string, plus any supporting client or console tooling you add. It has a character limit of 500.

---

## 🚀 Getting Started

Below are the steps and requirements to get this project running on your local machine.

### ✅ Requirements

Make sure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)  
- [Docker](https://www.docker.com/)

### 📥 Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/bakfietsje/UNameItAssignment.git
   cd UNameItAssignment
## 💻 Usage

### 🛠 Build the Docker images:

```bash
docker build -t uname .
```

### 🌐 Start the Web API in detached mode:

```bash
 docker run -d `--name uname `-e ASPNETCORE_URLS="http://+:8080" `-p 8080:8080 ` uname 
```  
> You should now be able to access the API at http://localhost:8080/api/WordCloud/word-count`
> Example POST call in JSON:
```bash
{
  "text": "De specialisten van UnameIT werken met liefde voor het vak aan innovatieve producten en kennen de branche. We willen de allerbeste tools maken waar onze automotive klanten écht mee geholpen zijn. "
}
``` 


