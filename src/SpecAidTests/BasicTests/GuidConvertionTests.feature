@TypeConvertionTestsSteps
Feature: GuidConvertionTests

Scenario: GuidConvertionTests - Regular Guid
    Given There are EveryThing Objects
        | aGuid                                |
        | 11ab0769-41cb-4655-b05d-621cc17585d4 |

    Then There are EveryThing Objects
        | aGuid                                |
        | 11ab0769-41cb-4655-b05d-621cc17585d4 |

Scenario: GuidConvertionTests - Nullable Guid
    Given There are EveryThing Objects
        | aNullableGuid                        |
        | 11ab0769-41cb-4655-b05d-621cc17585d4 |
        | null                                 |

    Then There are EveryThing Objects
        | aNullableGuid                        |
        | 11ab0769-41cb-4655-b05d-621cc17585d4 |
        | null                                 |

Scenario: GuidConvertionTests - Guid to String
    Given There are EveryThing Objects
        | Tag It | A String                             | A Nullable Guid                      |
        | #eto1  | 11ab0769-41cb-4655-b05d-621cc17585d4 | 11ab0769-41cb-4655-b05d-621cc17585d4 |

    Then There are EveryThing Objects
        | A String            |
        | #eto1.ANullableGuid |

Scenario: GuidConvertionTests - Null Guid to Null
    Given There are EveryThing Objects
        | Tag It | A String | A Nullable Guid |
        | #eto1  | null     | null            |

    Then There are EveryThing Objects
        | A String            |
        | #eto1.ANullableGuid |

Scenario: GuidConvertionTests - Lower Case Guid to Upper Case String
    Given There are EveryThing Objects
        | Tag It | A String                             | A Nullable Guid                      |
        | #eto1  | 11AB0769-41CB-4655-B05D-621CC17585D4 | 11ab0769-41cb-4655-b05d-621cc17585d4 |

    Then There are EveryThing Objects
        | A String            |
        | #eto1.ANullableGuid |
