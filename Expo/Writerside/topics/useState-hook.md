# useState hook

```jsx
import React, { useState } from 'react';
import { Button, Text, View } from 'react-native';

const Cat = (props) => {
  const [isHungry, setIsHungry] = useState(true);

  return (
    <View>
      <Text>
        I am {props.name}, and I am {isHungry ? "hungry" : "full"}!
      </Text>
      <Button
        title={isHungry ? "Pour me some milk, please!" : "Thank you!"}
        onPress={() => setIsHungry(false)}
        disabled={!isHungry}
      />
    </View>
  );
};

const Cafe = () => {
  return (
    <> 
      <Cat name="cat1" />
      <Cat name="cat2" />
    </> 
  );
};
```