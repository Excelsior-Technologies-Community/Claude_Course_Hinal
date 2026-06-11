# 🤖 Claude API — ASP.NET MVC Demo

A hands-on course project demonstrating how to integrate **Anthropic's Claude API** into a classic **ASP.NET MVC 5 (.NET Framework 4.8)** web application. The project covers core API concepts including chat completions, streaming, tool use, extended thinking, image input, and LLM evaluation.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Modules](#modules)
- [NuGet Packages](#nuget-packages)
- [License](#license)

---

## Overview

This project is built as a learning resource for the **Claude API Course**. It walks through real-world usage patterns of the Claude API, from simple chat interactions to advanced features like streaming responses, tool/function calling, image vision, and automated LLM evaluation pipelines.

---

## 📁 Project Structure

```
Claude_Course_Hinal/
│
├── CLAUDE_API/                         # Main ASP.NET MVC 5 Web Application
│   ├── App_Start/
│   │   └── RouteConfig.cs              # MVC route configuration
│   │
│   ├── Controllers/
│   │   ├── ChatController.cs           # Chat demos (basic, streaming, prefill, etc.)
│   │   ├── EvalController.cs           # LLM evaluation pipeline controller
│   │   ├── FeaturesController.cs       # Extended features (thinking, images)
│   │   └── ToolsController.cs          # Tool use / function calling demos
│   │
│   ├── Model/
│   │   ├── ChatHelpers.cs              # Utility helpers for chat formatting
│   │   ├── ChatMessage.cs              # Chat message model
│   │   ├── ClaudeService.cs            # Core Claude API service (HTTP client)
│   │   ├── EvalModels.cs               # Models for the evaluation module
│   │   ├── EvalServices.cs             # Evaluation logic and grading
│   │   ├── FeaturesService.cs          # Vision and thinking feature service
│   │   ├── RequestHelper.cs            # HTTP request builder helpers
│   │   ├── StaticChatData.cs           # Static seed data for demo conversations
│   │   └── ToolsService.cs             # Tool/function calling service
│   │
│   ├── Views/
│   │   ├── Chat/                       # Chat demo views
│   │   │   ├── Basic.cshtml            # Basic text chat
│   │   │   ├── Prefill.cshtml          # Response prefilling
│   │   │   ├── StopSequence.cshtml     # Stop sequences
│   │   │   ├── Streaming.cshtml        # Real-time streaming responses
│   │   │   ├── SystemPrompt.cshtml     # System prompt usage
│   │   │   ├── Temperature.cshtml      # Temperature / sampling controls
│   │   │   ├── _ChatNav.cshtml         # Chat navigation partial
│   │   │   └── _ChatScript.cshtml      # Shared chat JS partial
│   │   ├── Eval/
│   │   │   ├── Index.cshtml            # Evaluation dashboard
│   │   │   └── Dataset.cshtml          # Dataset-based evaluation view
│   │   ├── Features/
│   │   │   ├── Index.cshtml            # Features landing page
│   │   │   ├── Images.cshtml           # Vision / image input demo
│   │   │   └── Thinking.cshtml         # Extended thinking (CoT) demo
│   │   ├── Tools/
│   │   │   ├── Index.cshtml            # Tools landing page
│   │   │   ├── BasicTools.cshtml       # Basic tool/function calling demo
│   │   │   └── WebSearch.cshtml        # Web search tool demo
│   │   └── Shared/
│   │       └── _Layout.cshtml          # Shared layout template
│   │
│   ├── Content/
│   │   └── Site.css                    # Application stylesheet
│   │
│   ├── Global.asax                     # Application entry point
│   ├── Global.asax.cs                  # Application startup & routing
│   ├── Web.config                      # App configuration (API key, etc.)
│   ├── Web.Debug.config                # Debug transform
│   ├── Web.Release.config              # Release transform
│   ├── packages.config                 # NuGet package references
│   ├── CLAUDE_API.csproj               # MSBuild project file
│   └── CLAUDE_API.sln                  # Visual Studio solution file
│
├── .gitignore                          # Git ignore rules
├── .gitattributes                      # Git attributes (line endings, diff)
└── README.md                           # This file
```

---

## ✨ Features

| Module | Description |
|--------|-------------|
| **Basic Chat** | Simple single-turn and multi-turn conversations with Claude |
| **System Prompt** | Custom system prompts to shape Claude's persona and behavior |
| **Streaming** | Real-time token-by-token streaming responses using SSE |
| **Temperature** | Explore how temperature affects response creativity |
| **Prefill** | Guide Claude's response by prefilling the assistant turn |
| **Stop Sequences** | Control where Claude stops generating |
| **Tool Use** | Function/tool calling — let Claude invoke custom C# functions |
| **Web Search Tool** | Claude-powered web search integration |
| **Vision / Images** | Send images to Claude and get multimodal responses |
| **Extended Thinking** | Chain-of-thought reasoning with Claude's thinking feature |
| **LLM Evaluation** | Automated evaluation pipeline to grade model responses |

---

## 🔧 Prerequisites

- [Visual Studio 2019 / 2022](https://visualstudio.microsoft.com/) (with ASP.NET workload)
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- [IIS Express](https://learn.microsoft.com/en-us/iis/extensions/introduction-to-iis-express/iis-express-overview) (bundled with Visual Studio)
- An **Anthropic API Key** — get one at [console.anthropic.com](https://console.anthropic.com/)

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Excelsior-Technologies-Community/Claude_Course_Hinal.git
cd Claude_Course_Hinal
```

### 2. Open in Visual Studio

Open `CLAUDE_API/CLAUDE_API.sln` in Visual Studio.

### 3. Restore NuGet packages

In Visual Studio: **Tools → NuGet Package Manager → Manage NuGet Packages for Solution → Restore**

Or via Package Manager Console:

```powershell
nuget restore CLAUDE_API/CLAUDE_API.sln
```

### 4. Configure your API Key

See the [Configuration](#configuration) section below.

### 5. Run the project

Press **F5** or click **▶ Start** in Visual Studio. The app will open on `http://localhost:59761/`.

---

## ⚙️ Configuration

Add your Anthropic API key to `CLAUDE_API/Web.config` inside the `<appSettings>` block:

```xml
<appSettings>
  <add key="CLAUDE_API_KEY" value="sk-ant-YOUR_KEY_HERE" />
</appSettings>
```

> [!CAUTION]
> **Never commit your API key to source control.** The `.gitignore` already excludes `Web.config` transforms, but ensure your key is not hardcoded in the committed `Web.config`. Prefer environment variables or [Azure Key Vault](https://azure.microsoft.com/en-us/products/key-vault) for production.

---

## 📦 NuGet Packages

| Package | Version | Purpose |
|---------|---------|---------|
| `Microsoft.AspNet.Mvc` | 5.2.9 | ASP.NET MVC framework |
| `Microsoft.AspNet.Razor` | 3.2.9 | Razor view engine |
| `Microsoft.AspNet.WebPages` | 3.2.9 | Web Pages helpers |
| `Newtonsoft.Json` | 13.0.4 | JSON serialization/deserialization |
| `Microsoft.Net.Http` | 2.2.29 | HTTP client extensions |
| `Microsoft.CodeDom.Providers.DotNetCompilerPlatform` | 2.0.1 | Roslyn compiler support |
| `Microsoft.Web.Infrastructure` | 2.0.0 | ASP.NET infrastructure |
| `Microsoft.Bcl` | 1.1.10 | Base class library portability |
| `Microsoft.Bcl.Build` | 1.0.14 | BCL build tasks |

---

## 📄 License

This project is for **educational purposes** as part of the Claude API Course.

---

> Built with ❤️ using [Anthropic Claude](https://www.anthropic.com/) + ASP.NET MVC 5
