# scope-timer
Scope timer for dotnet with inner scopes

```C#
public void MyMethod()
{
    using (var scope = new Scope(GetType().Name + "." + nameof(MyMethod)))
    {
        using (scope.Inner("SomeInnerScope1"))
        {
            ...
        }
        
        using (var innerScope2 = scope.Inner("SomeInnerScope2"))
        {
            ...
            using (innerScope2.Inner("SomeExtraInnerScope"))
            {
                ...
                ...
            }
            ...
        }
        
        using (scope.Inner("SomeInnerScope3"))
        {
            ...
        }
        
        var timing = scope.Timing;
        ... /// Log timinig somewhere
    }
}
```

Example of data
```json
"timing": {
    "scopeName": "MyService.MyMethod",
    "elapsed": "00:00:00.0755708",
    "innerScopes": [
        {
            "scopeName": "SomeInnerScope1",
            "elapsed": "00:00:00.0074690",
            "innerScopes": []
        },
        {
            "scopeName": "SomeInnerScope2",
            "elapsed": "00:00:00.0434156",
            "innerScopes": [
                {
                    "scopeName": "SomeExtraInnerScope",
                    "elapsed": "00:00:00.013306",
                    "innerScopes": []
                }
            ]
        },
        {
            "scopeName": "SomeInnerScope3",
            "elapsed": "00:00:00.0240118",
            "innerScopes": []
        }
    ]
}
```
