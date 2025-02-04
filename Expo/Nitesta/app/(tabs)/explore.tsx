import {StyleSheet, Image, Platform, View, Text, Button} from 'react-native';
import {useState} from "react";

const Cat = (props) =>{
    const [isHungry,setIsHungry] = useState(true);

    return(
        <View>
            <Text>
                I am {props.name}, and I am {isHungry?"hungry":"full"}!
            </Text>
            <Button title={isHungry?"Pour me some milk, please!":"Thank you!"}
                    onPress={() => {setIsHungry(false);}}
                    disabled={!isHungry}/>
        </View>)
}


export default function TabTwoScreen() {
  return (
      <>
          <Cat name="cat1"/>
          <Cat name="cat2"/>
      </>
  );
}

const styles = StyleSheet.create({
  headerImage: {
    color: '#808080',
    bottom: -90,
    left: -35,
    position: 'absolute',
  },
  titleContainer: {
    flexDirection: 'row',
    gap: 8,
  },
});
