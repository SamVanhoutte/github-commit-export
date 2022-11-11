# Github commit exporter

A console app that extracts all commits of a specific github repo and dumps it into a CSV

## Purpose

I had been working for a startup and I wanted to guestimate when I worked and how many hours I typically had spent, writing code for them.  
Therefore, I just exported all my commits to the main branch (this includes those that get through PR's) to a CSV file, that I then used to make a cleaner report (cleaning out descriptions, removing lines, etc)

## How it works

### Create a Github PAT

Create a Github PAT (personal access token):

1. Navigate to [your developer settings on Github](https://github.com/settings/tokens)
1. Generate new token (classic)
1. Give it a name to remember, select an expiration period you want
1. Select `repo`
1. Click Generate Token
1. Copy the token (you will not be able to retrieve it later)

### Update the appsettings.json

Fill out the appsettings.json with all the correct information:

```json
{
    "Github": 
    {
        "owner": "",
        "repo": "",
        "userName": "",
        "pat": ""
    }
}
```

- **owner**: the owner of the repo you want to query (a user or organization)
- **repo**: the name of the repository
- **userName**: your user name
- **pat**: your specific Personal Access Token