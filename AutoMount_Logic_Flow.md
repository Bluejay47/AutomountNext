# AutoMount Logic Flow Documentation

This document provides a comprehensive overview of the AutoMount system's logic flow, showing how mounting is handled across different scenarios with the two combat features.

## System Overview

The AutoMount system has two main automated mounting features:
1. **Auto Mount When In Combat** - Stay mounted while in combat
2. **Auto Mount When Not In Combat** - Stay mounted while not in combat (including area transitions)

## Main Logic Flow

```mermaid
flowchart TD
    A[Event Trigger] --> B{Event Type?}

    B -->|Combat Start| C[HandleUnitJoinCombat]
    B -->|Combat End| D[HandleUnitLeaveCombat]
    B -->|Area Load| E[OnAreaDidLoad]
    B -->|Manual Hotkey| F[Manual Mount/Dismount]

    %% Combat Start Flow
    C --> C1{Is Party Member?}
    C1 -->|No| C2[Skip - Not Party Member]
    C1 -->|Yes| C3{Has Auto Mount When In Combat Buff?}
    C3 -->|Yes| C4[Schedule Mount for Next Frame]
    C3 -->|No| C5[Schedule Dismount for Next Frame]

    %% Combat End Flow
    D --> D1{Is Party Member?}
    D1 -->|No| D2[Skip - Not Party Member]
    D1 -->|Yes| D3{Has Auto Mount When Not In Combat Buff?}
    D3 -->|Yes| D4[Schedule Mount for Next Frame]
    D3 -->|No| D5[Schedule Dismount for Next Frame]

    %% Area Load Flow
    E --> E1{Check Etudes for Pet Blockers}
    E1 -->|Blocked| E2[Skip All - Area Restricted]
    E1 -->|Safe| E3[Grant Abilities to Party]
    E3 --> E4[For Each Party Member]
    E4 --> E5{Has Auto Mount When Not In Combat Buff?}
    E5 -->|Yes| E6[Attempt Mount]
    E5 -->|No| E7[Skip Member]

    %% Manual Flow
    F --> F1[For Each Party Member]
    F1 --> F2{Check Mount State}
    F2 -->|Mount Request| F3[Attempt Mount]
    F2 -->|Dismount Request| F4[Attempt Dismount]

    %% Mount Attempt Flow
    C4 --> G[ProcessPendingOperations]
    D4 --> G
    E6 --> H[Direct Mount Attempt]
    F3 --> H

    G --> G1{Time Delay Passed?}
    G1 -->|No| G2[Wait]
    G1 -->|Yes| G3[Execute TryMountUnit]

    H --> I{Check Area Restrictions}
    G3 --> I

    I -->|Aivu + Drezen Basement| I1[Special Aivu Exception]
    I -->|Blocked by Etudes| I2[Block Mount - Log Message]
    I -->|Safe Area| I3[Continue Mount Process]

    I1 --> I3
    I3 --> J{Unit State Check}

    J -->|DisableMountRiding| J1[Block - Console Warning]
    J -->|Valid| J2[Get Rider's Pet]

    J2 --> K{Pet Available?}
    K -->|No| K1[Skip - No Pet]
    K -->|Yes| K2{CheckCanMount Validation}

    K2 -->|Failed| K3[Skip - Mount Check Failed]
    K2 -->|Passed| K4{Mount Ability Available?}

    K4 -->|No Ability| K5[Skip - No Mount Ability]
    K4 -->|Available| K6{Already Mounted?}

    K6 -->|Yes| K7[Skip - Already Mounted]
    K6 -->|No| K8[Execute Mount]

    K8 --> L[unit.Ensure UnitPartRider Mount pet]
    L --> M[Log Success Message]

    %% Dismount Flow
    C5 --> N[ProcessPendingOperations - Dismount]
    D5 --> N
    F4 --> O[Direct Dismount Attempt]

    N --> N1{Time Delay Passed?}
    N1 -->|No| N2[Wait]
    N1 -->|Yes| N3[Execute TryDismountUnit]

    O --> P{Unit Has RiderPart?}
    N3 --> P

    P -->|No| P1[Skip - Not Mounted]
    P -->|Yes| P2[unit.RiderPart.Dismount]
    P2 --> P3[Log Success Message]

    %% Styling
    classDef eventNode fill:#e1f5fe
    classDef decisionNode fill:#fff3e0
    classDef actionNode fill:#e8f5e8
    classDef errorNode fill:#ffebee
    classDef specialNode fill:#f3e5f5

    class A,C,D,E,F eventNode
    class B,C1,C3,D1,D3,E1,E5,F2,G1,I,J,K,K2,K4,K6,N1,P decisionNode
    class C4,C5,D4,D5,E3,E6,F3,F4,G3,H,I3,J2,K8,L,M,N3,O,P2,P3 actionNode
    class C2,D2,E2,E7,I2,J1,K1,K3,K5,K7,P1 errorNode
    class I1 specialNode
```

## Feature Interaction Matrix

```mermaid
flowchart LR
    subgraph "Combat Features"
        A[Auto Mount When In Combat<br/>Toggle Feature] --> A1[When In Combat Buff<br/>Active/Inactive]
        B[Auto Mount When Not In Combat<br/>Toggle Feature] --> B1[When Not In Combat Buff<br/>Active/Inactive]
    end

    subgraph "Scenarios"
        C[Combat Start Event]
        D[Combat End Event]
        E[Area Transition]
        F[Manual Hotkey]
    end

    subgraph "Behavior Matrix"
        G[Combat Start: Mount if When In Combat Buff Active<br/>Combat Start: Dismount if When In Combat Buff Inactive]
        H[Combat End: Mount if When Not In Combat Buff Active<br/>Combat End: Dismount if When Not In Combat Buff Inactive]
        I[Area Load: Mount if When Not In Combat Buff Active<br/>Area Load: Skip if When Not In Combat Buff Inactive]
        J[Manual: Force Mount/Dismount<br/>Manual: Override Feature Settings]
    end

    C --> G
    D --> H
    E --> I
    F --> J

    A1 --> G
    B1 --> H
    B1 --> I
```

## Safety Checks and Validation Flow

```mermaid
flowchart TD
    A[Mount Request] --> B{Etude Check}
    B -->|Area Blocked| B1[BLOCK: Pet Restricted Area]
    B -->|Area Safe| C{Unit State Check}

    C -->|DisableMountRiding| C1[BLOCK: Mounting Disabled]
    C -->|Valid State| D{Pet Availability}

    D -->|No Pet| D1[BLOCK: No Pet Available]
    D -->|Pet Available| E{Size Compatibility}

    E -->|Size Mismatch| E1[BLOCK: Size Incompatible]
    E -->|Size Compatible| F{Mount Ability Check}

    F -->|No Ability| F1[BLOCK: No Mount Ability]
    F -->|Ability Available| G{Already Mounted Check}

    G -->|Already Mounted| G1[SKIP: Already Mounted]
    G -->|Not Mounted| H{Special Area Checks}

    H -->|Aivu + Drezen Basement| H1[ALLOW: Special Exception]
    H -->|Normal Area| H2[ALLOW: Execute Mount]

    H1 --> I[SUCCESS: Mount Executed]
    H2 --> I

    classDef blockNode fill:#ffebee
    class B1,C1,D1,E1,F1 blockNode

    classDef skipNode fill:#fff8e1
    class G1 skipNode

    classDef allowNode fill:#e8f5e8
    class H1,H2,I allowNode
```

## Event Processing Timeline

```mermaid
timeline
    title AutoMount Event Processing Timeline

    section Game Start
        Game Load : Mod Initialization
                  : Harmony Patches Applied
                  : Event Handlers Registered

    section Area Transition
        Area Load Start : OnAreaBeginUnloading() Called
        Area Load End : OnAreaDidLoad() Called
                     : GrantAutoMountAbilities()
                     : Etude Safety Check
                     : Mount Characters with When Not In Combat Buff

    section Combat Events
        Combat Start : HandleUnitJoinCombat() Called
                    : Check When In Combat Buff
                    : Schedule Mount/Dismount
        Next Frame : ProcessPendingOperations()
                  : Execute Delayed Mount/Dismount
        Combat End : HandleUnitLeaveCombat() Called
                  : Check When Not In Combat Buff
                  : Schedule Mount/Dismount
        Next Frame : ProcessPendingOperations()
                  : Execute Delayed Mount/Dismount

    section Manual Actions
        Hotkey Press : Mount() Called with Force Flag
                    : Bypass Feature Checks
                    : Direct Mount/Dismount Attempt
```

## Error Handling and Edge Cases

### Special Handling Cases:

1. **Aivu Exception**: Special case for Drezen basement area where Aivu can mount despite area restrictions
2. **Size Validation**: Checks mount size compatibility with TTT Undersized Mount feat support
3. **Combat Delays**: 0.1 second delay on combat events to avoid event system conflicts
4. **Area Etude Blocks**: Dynamic area detection that prevents mounting in problematic areas
5. **Party Member Validation**: Only processes party members, ignores NPCs and enemies

### Error Recovery:
- All mount/dismount operations are wrapped in try-catch blocks
- Failed operations are logged and removed from pending queues
- Invalid units are skipped with appropriate debug logging
- Missing abilities or features are detected and logged

### Feature Interaction:
- Auto Mount When In Combat and Auto Mount When Not In Combat features are independent
- Area load only respects Auto Mount When Not In Combat feature settings
- Manual hotkeys override all automatic feature settings
- Each character can have different feature preferences