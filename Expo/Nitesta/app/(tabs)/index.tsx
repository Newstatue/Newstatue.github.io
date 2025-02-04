import {Image, StyleSheet, Platform, View, Text, Button} from 'react-native';
import {useState} from "react";


const Cat = (props) =>{
    const[isHungry, setIsHungry] = useState(true);
    return( <View>
        <Text>
            I am {props.name}, and i am {isHungry?"hungry":"full"}!
        </Text>
        <Button title={isHungry?"Pour me some milk, please!":"Thank you!"}
                onPress={()=>{setIsHungry(false);}}
                disabled={!isHungry}
        />
    </View>)
}


export default function HomeScreen() {
  return (
      <>
          <Cat name="Munkustrap" />
          <Cat name="Spot" />
      </>
  );
}



const styles = StyleSheet.create({
  titleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
  },
  stepContainer: {
    gap: 8,
    marginBottom: 8,
  },
  reactLogo: {
    height: 178,
    width: 290,
    bottom: 0,
    left: 0,
    position: 'absolute',
  },
});
