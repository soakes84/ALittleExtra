import React, { Component } from 'react';
import { StaggeredMotion, spring } from 'react-motion';


const colors = [
   '#B9F6CA',
   '#69F0AE',
   '#00E676',
   '#00C853'
]

const Box = (props) => {
   const styles = {
      flexBasis: `${props.width}%`,
      background: `${props.bgColor}`
   }
   return (
      <div className="box" style={styles}></div>
   )
}
const LoginWrapper = (props) => {
   return (
      <div className="columns small-12 main-green">
         <h3>Welcome to Muncher!</h3>
         <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Velit ab iste officiis dolore eum, esse eveniet obcaecati aspernatur accusamus facilis nulla culpa nostrum reiciendis sapiente, veniam soluta, nemo in id.</p>
      </div>
   )
}

export default class Login extends Component {
   render(){
      return(
         <StaggeredMotion
            defaultStyles={[
               { width: 100 },
               { width: 100 },
               { width: 100 },
            ]}
            styles={(prevStyles) =>
            [   { width: spring(0) },
               { width: spring(prevStyles[0].width) },
               { width: spring(prevStyles[1].width) }
            ]}

         >
               {(styles) => (
                  <div className="grid-x" style={{width: '100vw', height: '100vh', flexFlow: 'nowrap'}}>
                     <Box bgColor={colors[0]} width={styles[0].width} />
                     <Box bgColor={colors[1]} width={styles[1].width} />
                     <Box bgColor={colors[2]} width={styles[2].width} />
                     <LoginWrapper/>
                  </div>
               )}

         </StaggeredMotion>

      )
   }
}
