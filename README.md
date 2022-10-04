# mermaid-decision-tree

Convert decisions saved as json into mermaid charts.

## sample rendering

f# input:

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

json input:

```json
{
  "Id": "e4e91c62-064f-47cd-ada7-7abce67af4e9",
  "Description": "hello world!",
  "Note": "note!\nline 2\n\tformatted line 3",
  "Child": [
    {
      "Id": "07c1bfc9-3ce0-4415-a889-b207c13906b2",
      "Description": "child 1",
      "Note": "note 1",
      "Child": [
        {
          "Id": "4f0c5d8e-d93d-4290-877e-2ae145950e61",
          "Description": "child 2",
          "Note": "note 2",
          "Child": null
        },
        {
          "Id": "061a7183-55b7-4561-8ae8-8f60c249dfbf",
          "Description": "child 3",
          "Note": "note 3",
          "Child": null
        }
      ]
    }
  ]
}
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
state "hello world!" as e1af3ddb14fe4494a34030ded7bfffe7

note right of e1af3ddb14fe4494a34030ded7bfffe7
note!
line 2
        formatted line 3
end note
state "child 1" as 69a0e36f4e3844239146a7fa5afcd086

note right of 69a0e36f4e3844239146a7fa5afcd086
note 1
end note
state "child 2" as e1b0084c23ff4785a05181fc322f9c35
e1b0084c23ff4785a05181fc322f9c35 --> [*]
note right of e1b0084c23ff4785a05181fc322f9c35
note 2
end note

69a0e36f4e3844239146a7fa5afcd086 --> e1b0084c23ff4785a05181fc322f9c35
state "child 3" as a560ac44da3d468986516e2fc6bc7678
a560ac44da3d468986516e2fc6bc7678 --> [*]
note right of a560ac44da3d468986516e2fc6bc7678
note 3
end note

69a0e36f4e3844239146a7fa5afcd086 --> a560ac44da3d468986516e2fc6bc7678

e1af3ddb14fe4494a34030ded7bfffe7 --> 69a0e36f4e3844239146a7fa5afcd086

[*] --> e1af3ddb14fe4494a34030ded7bfffe7
```