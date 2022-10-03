# mermaid-decision-tree

Convert decisions saved as json into mermaid charts.

## sample rendering

input:

```f#
Decision(
    Guid.NewGuid(),
    "hello world!",
    "note!\nline 2\n\tformatted line 3",
    Some(
        seq {
            Decision(
                Guid.NewGuid(),
                "child 1",
                "note 1",
                Some(
                    seq {
                        Decision(Guid.NewGuid(), "child 2", "note 2", None)
                        Decision(Guid.NewGuid(), "child 3", "note 3", None)
                    }
                )
            )
        }
    )
)
```

output:

~~~
```mermaid
stateDiagram-v2
state "hello world!" as be662f8d2ed041159b8ce393d97d36ad

note right of be662f8d2ed041159b8ce393d97d36ad
note!
line 2
        formatted line 3
end note
state "child 1" as e44b01ad89244839a30baf7409c055c5

note right of e44b01ad89244839a30baf7409c055c5
note 1
end note
state "child 2" as 3744cf495efd4113876d6a523625b6bb
3744cf495efd4113876d6a523625b6bb --> [*]
note right of 3744cf495efd4113876d6a523625b6bb
note 2
end note

e44b01ad89244839a30baf7409c055c5 --> 3744cf495efd4113876d6a523625b6bb
state "child 3" as b0fa92cff14a4efd9618a9e89994dc9a
b0fa92cff14a4efd9618a9e89994dc9a --> [*]
note right of b0fa92cff14a4efd9618a9e89994dc9a
note 3
end note

e44b01ad89244839a30baf7409c055c5 --> b0fa92cff14a4efd9618a9e89994dc9a

be662f8d2ed041159b8ce393d97d36ad --> e44b01ad89244839a30baf7409c055c5

[*] --> be662f8d2ed041159b8ce393d97d36ad
```
~~~

rendered output:

```mermaid
stateDiagram-v2
state "hello world!" as be662f8d2ed041159b8ce393d97d36ad

note right of be662f8d2ed041159b8ce393d97d36ad
note!
line 2
        formatted line 3
end note
state "child 1" as e44b01ad89244839a30baf7409c055c5

note right of e44b01ad89244839a30baf7409c055c5
note 1
end note
state "child 2" as 3744cf495efd4113876d6a523625b6bb
3744cf495efd4113876d6a523625b6bb --> [*]
note right of 3744cf495efd4113876d6a523625b6bb
note 2
end note

e44b01ad89244839a30baf7409c055c5 --> 3744cf495efd4113876d6a523625b6bb
state "child 3" as b0fa92cff14a4efd9618a9e89994dc9a
b0fa92cff14a4efd9618a9e89994dc9a --> [*]
note right of b0fa92cff14a4efd9618a9e89994dc9a
note 3
end note

e44b01ad89244839a30baf7409c055c5 --> b0fa92cff14a4efd9618a9e89994dc9a

be662f8d2ed041159b8ce393d97d36ad --> e44b01ad89244839a30baf7409c055c5

[*] --> be662f8d2ed041159b8ce393d97d36ad
```