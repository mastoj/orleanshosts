.PHONY: build clean test list run

# Set the default goal to 'list'
.DEFAULT_GOAL := list

# Example targets
build: ## build
	@echo "Building the project..."
	dotnet build

clean: ## clean
	@echo "Cleaning the project..."

test: ## test
	@echo "Running tests..."

# Target to list all available targets
list:
	@awk -F ': ##' '/^[a-zA-Z0-9][a-zA-Z0-9_-]*: ##/ {printf "%-15s %s\n", $$1, $$2}' Makefile

# Target to run the dotnet projects in parallel
run-worker1: ## run worker1
	dotnet run --project WorkerSample

run-worker2: ## run worker2
	dotnet run --project WorkerSample

run-api: ## run api
	dotnet run --project Api
